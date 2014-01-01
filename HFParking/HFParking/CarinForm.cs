using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using LogisTechBase;
using System.Text.RegularExpressions;
using nsConfigDB;

namespace HFParking
{
    public partial class CarinForm : Form
    {

        private bool isMouseDown = false;
        private Point FormLocation;
        private Point mouseOffset; 
        LoginForm lg = null;
        DataColumn dc = null;
        private System.IO.Ports.SerialPort comport = new System.IO.Ports.SerialPort();//定义串口
        private bool bClosing = false;
        bool isPortOpen = false;
        bool isReading = false;
        Button []bt=new Button [6];
        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        public CarinForm()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
            this.comport.PortName = ConfigDB.getConfig("serialPortName").ToString();
            //this.comport.PortName = "com37";
            this.comport.StopBits = StopBits.One;
            this.comport.Parity = Parity.None;
            this.comport.DataBits = 8;
            this.comport.BaudRate = 115200;
            this.comport.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(comport_DataReceived);
            this._timer.Interval = 2000;
            this._timer.Tick += new EventHandler(_timer_Tick);
            axShockwaveFlash1.Movie = Application.StartupPath + @"\pictures\出入车辆.swf";
           
            //dc = lg.dtall.Columns.Add("ID", Type.GetType("System.Int32"));
            //dc.AutoIncrement = true;//自动增加
            //dc.AutoIncrementSeed = 1;//起始为1
            //dc.AutoIncrementStep = 1;//步长为1
            //dc.AllowDBNull = false;//
            //dc = lg.dtall.Columns.Add("EPC", Type.GetType("System.String"));
            //dc = lg.dtall.Columns.Add("UserName", Type.GetType("System.String"));
            //dc = lg.dtall.Columns.Add("Time", Type.GetType("System.String"));
        } 
        int currentProto = 2;
        void _timer_Tick(object sender, EventArgs e)
        {
            //this.comport.Write(HFCommandItem.设置15693协议);
            //Thread.Sleep(300);
            if (isPortOpen)
            {
                if (this.isReading == true)
                {
                    string str1Write = string.Empty;
                    string str2Write = string.Empty;
                    switch (currentProto)
                    {
                        case 1://tagit
                            str1Write = HFCommandItem.设置TAGIT协议;
                            str2Write = HFCommandItem.读取TAGIT协议标签;
                            Debug.WriteLine(
                                string.Format("frmHFRead._timer_Tick  ->  = {0}"
                                , "读取TAGIT协议标签"));

                            break;
                        case 2://
                            str1Write = HFCommandItem.设置15693协议;
                            str2Write = HFCommandItem.读取15693协议标签;
                            Debug.WriteLine(
    string.Format("frmHFRead._timer_Tick  ->  = {0}"
    , "读取15693协议标签"));

                            break;
                        case 3://
                            str1Write = HFCommandItem.设置14443A协议;
                            str2Write = HFCommandItem.读取14443A协议标签;
                            Debug.WriteLine(
    string.Format("frmHFRead._timer_Tick  ->  = {0}"
    , "读取14443A协议标签"));

                            break;
                        case 4://
                            str1Write = HFCommandItem.设置14443B协议;
                            str2Write = HFCommandItem.读取14443B协议标签;
                            Debug.WriteLine(
    string.Format("frmHFRead._timer_Tick  ->  = {0}"
    , "读取14443B协议标签"));

                            break;
                    }

                    this.comport.Write(str1Write);
                    Thread.Sleep(300);
                    try
                    {
                        //转换列表为数组后发送
                        //comport.Write(bytesCommandToWrite, 0, bytesCommandToWrite.Length);
                        this.comport.Write(HFCommandItem.读取15693协议标签);
                    }
                    catch (System.Exception ex)
                    {
                        Debug.WriteLine(
                            string.Format("frmHFRead._timer_Tick  ->  = {0}"
                            , ex.Message));
                    }
                }
            }
        }
        StringBuilder buffer = new StringBuilder();
        void protocal_parse(string data)
        {
            buffer.Append(data);

            //解析返回的数据
            // 首先确定已经接收到的数据中含有指示命令和标签UID
            string currentData = buffer.ToString();

            Debug.WriteLine(
                string.Format("frmHFRead.comport_DataReceived  -> current buffer = {0}"
                , currentData));

            int iTagit = -1;
            int i1443a = -1;
            int i1443b = -1;
            int i15693 = -1;
            int iPro = -1;
            string strPro = string.Empty;
            iTagit = currentData.IndexOf(HFCommandItem.读取TAGIT协议标签);
            if (iTagit >= 0)
            {
                iPro = iTagit;
                strPro = "TAGIT协议";
                goto Found;
            }
            i1443a = currentData.IndexOf(HFCommandItem.读取14443A协议标签);
            if (i1443a >= 0)
            {
                iPro = i1443a;
                strPro = "14443A协议";

                goto Found;
            }
            i1443b = currentData.IndexOf(HFCommandItem.读取14443B协议标签);
            if (i1443b >= 0)
            {
                iPro = i1443b;
                strPro = "14443B协议";
                goto Found;
            }
            i15693 = currentData.IndexOf(HFCommandItem.读取15693协议标签);
            if (i15693 >= 0)
            {
                iPro = i15693;
                strPro = "15693协议";
                goto Found;
            }

        Found: if (iPro > -1)
            {
                int iright = -1;
                iright = currentData.LastIndexOf("]");//先检测右边括号，没有右边的话说明数据不完整
                if ((iright > -1) && iright > iPro)// ] 必须在协议的后面，否则就说明这不是同一个数据段
                {
                    int ileft = -1;
                    ileft = currentData.LastIndexOf("[");
                    if (ileft != -1 && ileft < iright)
                    {
                        string tagID = string.Empty;
                        tagID = currentData.Substring(ileft + 1, iright - ileft - 1);
                        if (tagID.Length > 0)
                        {
                            int dindex = tagID.IndexOf(",");
                            if (dindex >= 0)
                            {
                                tagID = tagID.Substring(0, dindex);

                            }
                            bool isHexa = Regex.IsMatch(tagID, "^[0-9A-Fa-f]+$");
                            if (isHexa&&tagID != null && tagID.Length > 0)
                            {
                                Debug.WriteLine(
                                                string.Format("frmHFRead.comport_DataReceived  -> tagID = {0}"
                                                , tagID));
                                carInaction(tagID);
                            }
                        }

                        buffer.Remove(0, iright + 1);
                    }
                }
            }
            //if (buffer.IndexOf("\r\n") != -1)
            //{
            //this.Invoke(new deleUpdateContorl(updateText), buffer);
            //buffer = string.Empty;
            //}
        }
       void carInaction(string tagID)
       {
           this.textBox1.Text = tagID;
           axShockwaveFlash1.Play();

       }
        void comport_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (this.bClosing == true)
            {
                return;
            }
            try
            {
                string temp = comport.ReadExisting();

                this.protocal_parse(temp);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(
                    string.Format("frmHFRead.comport_DataReceived  -> exception = {0}"
                    , ex.Message));
            }
        }
        private void addCarInfo(string EPC, string UserName)
        {
            if (!isExist(EPC))
            {
                bt[lg.dtall.Rows.Count].BackgroundImage = Image.FromFile(Application.StartupPath + @"\pictures\车位满.jpg");
                DataRow newRow;
                newRow = lg.dtall.NewRow();
                newRow["EPC"] = EPC;
                newRow["UserName"] = UserName;
                newRow["Time"] = DateTime.Now.ToString();
                lg.dtall.Rows.Add(newRow);
              
            }
            else 
            {
                MessageBox.Show("此车已注册！");
            }
        }
        private bool isExist(string epc) 
        {
            bool falg=false;
            for (int i = 0; i < lg.dtall.Rows.Count; i++)
            {
                if (lg.dtall.Rows[i]["EPC"].ToString() == epc)
                    falg=true;
            }
            return falg;
        } 
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                comport.Open();
                isPortOpen = true;
                _timer.Enabled = true;
                this.isReading = true;
            }catch (Exception ex){}
            bt[0] = button1;
            bt[1] = button2;
            bt[2] = button3;
            bt[3] = button4;
            bt[4] = button5;
            bt[5] = button6;
            for (int i = 0; i < lg.dtall.Rows.Count;i++ )
            {
                bt[i].BackgroundImage = Image.FromFile(Application.StartupPath + @"\pictures\车位满.jpg");
            }
        }
        public void GetForm(LoginForm theform)
        {
            lg = theform;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            lg.addDt();
            if(comport .IsOpen )
            {
             isPortOpen = false;
            comport.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (lg.dtall.Rows.Count >= 6) 
            {
                MessageBox.Show("车位已满，请等待空车位！"); return;
            }
           
            
            addCarInfo(textBox1 .Text ,"");

           
           
        }
        void setPicture() 
        {
        
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CarinForm_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void CarinForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            } 
           
        }

        private void CarinForm_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;

            if (isMouseDown)
            {
                Point pt =
                Control.MousePosition;

                _x = mouseOffset.X - pt.X;

                _y = mouseOffset.Y - pt.Y;

                this.Location = new
                      Point
                       (FormLocation.X - _x, FormLocation.Y - _y);
            }

 
        }

        private void button7_Click(object sender, EventArgs e)
        {
          
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
        }
    }
}
