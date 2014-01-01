using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InventoryMSystem;
using System.Text.RegularExpressions;
using FactorySystem.lei;
using RfidReader;
using System.Diagnostics;
using nsConfigDB;
using httpHelper;
using System.IO.Ports;

namespace FactorySystem
{
    public delegate void deleControlInvoke(object o);
    public partial class frmTiebiao : Form, IRFIDHelperSubscriber
    {
        Rmu900RFIDHelper rmu900Helper = null;
        IDataTransfer dataTransfer = null;
        SerialPort comport = null;

        string value = string.Empty;
        string Pid;
        public string getPid
        {
            get { return Pid; }

            set { Pid = value; }

        }
        string Num = "";
        public string getNum
        {
            get { return Num; }
            set { Num = value; }

        }
        bool alreadyWriteSuccess = false;
        public frmTiebiao()
        {
            InitializeComponent();
            this.Shown += new EventHandler(TiebiaoForm_Shown);
            this.FormClosing += new FormClosingEventHandler(frmEditEPC_FormClosing);

            this.cmbProductCategory.Items.Add("产品种类一");
            this.cmbProductCategory.Items.Add("产品种类二");
            this.cmbProductCategory.Items.Add("产品种类三");
            this.cmbProductCategory.Items.Add("产品种类四");
            this.cmbProductCategory.SelectedIndex = 0;
            this.lblTip.Text = string.Empty;

            dataTransfer = new SerialPortDataTransfer();
            try
            {
                comport = new SerialPort(staticClass.serialport_name, 57600, Parity.None, 8, StopBits.One);
                ((SerialPortDataTransfer)dataTransfer).Comport = comport;
            }
            catch (System.Exception ex)
            {

            }
            rmu900Helper = new Rmu900RFIDHelper(dataTransfer);
            rmu900Helper.Subscribe(this);
            dataTransfer.AddParser(rmu900Helper);
        }

        void TiebiaoForm_Shown(object sender, EventArgs e)
        {
            this.refrashdata();
        }
        void refrashdata()
        {
            string url = RestUrl.Find_code_Info;
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getproducingProduct);
            helper.TryRequest(url);
            return;
        }
        void helper_RequestCompleted_getproducingProduct(object o)
        {
            deleControlInvoke dele = delegate(object oProductList)
            {
                string strProduct = (string)oProductList;
                Debug.WriteLine(strProduct);

                object olist = fastJSON.JSON.Instance.ToObjectList(strProduct, typeof(List<Product>), typeof(Product));


                System.Data.DataTable dt = null;
                if (this.dv1.DataSource == null)
                {
                    dt = new System.Data.DataTable();
                    dt.Columns.Add("产品编号", typeof(string));
                    dt.Columns.Add("产品名称", typeof(string));
                    dt.Columns.Add("产品类别", typeof(string));
                    dt.Columns.Add("产品规格", typeof(string));
                }
                else
                {
                    dt = (System.Data.DataTable)dv1.DataSource;
                }
                dt.Rows.Clear();
                foreach (Product p in (List<Product>)olist)
                {
                    dt.Rows.Add(new object[]
                    {
                       p.Pro_code,p.Pro_Name,p.Pro_Leibie,p.Pro_Gui
                                             
                    });
                }
                dv1.DataSource = dt;

                this.dv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                int headerW = this.dv1.RowHeadersWidth;
                int columnsW = 0;
                DataGridViewColumnCollection columns = this.dv1.Columns;
                columns[0].Width = 100;
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsW += columns[i].Width;
                }
                if (columnsW + headerW < this.dv1.Width)
                {
                    int leftTotalWidht = this.dv1.Width - columnsW - headerW;
                    int eachColumnAddedWidth = leftTotalWidht / (columns.Count - 1);
                    for (int i = 1; i < columns.Count; i++)
                    {
                        columns[i].Width += eachColumnAddedWidth;
                    }
                }

            };

            this.Invoke(dele, o);

        }

        void frmEditEPC_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.closeSerialPort();
        }
        private void closeSerialPort()
        {
            bool bOk = false;
            // 如果没有全部完成，则要将消息处理让出，使Invoke有机会完成
            while (!bOk)
            {
                Application.DoEvents();
                bOk = true;
            }
            if (this.comport != null)
            {
                this.comport.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string strID = txtEpc.Text.Trim();
            this.alreadyWriteSuccess = false;
            this.writeTag(strID);
        }

        void addTieBiao()
        {
            string Pid = "产品A";
            string EPC = this.txtEpc.Text;
            Product p = new Product();
            p.Pro_code = EPC;
            p.Pro_Name = Pid;
            p.Pro_Leibie = this.cmbProductCategory.SelectedText;
            p.Pro_Gui = "100*200";
            p.Pro_state = "未入库";
            p.Pro_Pici = "12001234";
            p.Pro_Chej = "车间1";
            p.Pro_Person = "大伟";
            p.Contact = "18812394402";
            p.Remark = "机械零件";
            p.Pro_Tempre = "";
            p.Pro_Wet = "";
            p.finishTime = "";
            p.falg = "1";

            string url = RestUrl.add_New_Code;
            string jsonstr = string.Empty;
            jsonstr = fastJSON.JSON.Instance.ToJSON(p);
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getaddresult);
            helper.TryPostData(url, jsonstr);
        }
        void helper_RequestCompleted_getaddresult(object o)
        {
            string back = (string)o;
            if (back == "fail")
            {
                MessageBox.Show("添加失败！");
            }
            else if (back == "ok")
            {
                refrashdata();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.rmu900Helper.StartInventoryOnce();
        }
        void UpdateEpcList(object o)
        {
            Debug.WriteLine(
                string.Format("Form1.UpdateEpcList  ->  = {0}"
                , o.ToString()));
            //把读取到的标签epc与产品的进行关联
            deleControlInvoke dele = delegate(object oEpc)
            {
                string value = oEpc as string;
                this.txtEpc.Text = value;
            };
            this.Invoke(dele, o);
        }


        void writeTag(string str)
        {
            this.rmu900Helper.StartWriteEpc(str);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //ProduceProjectClass ppc = new ProduceProjectClass();
            //ppc.updateUserState(textBoxJD.Text, "待执行");
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            string time_stamp = DateTime.Now.ToString("yyyyMMddHHmmss");//长度14
            string epc = string.Format("000000{0}000{1}", time_stamp, (this.cmbProductCategory.SelectedIndex + 1).ToString());
            this.txtEpc.Text = epc;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.addTieBiao();
        }
        void helper_RequestCompleted_Put_toProduce(object o)
        {
            string back = (string)o;
            if (back == "ok")
            {
                frmProducing plist = new frmProducing();
                plist.StartPosition = FormStartPosition.CenterScreen;
                plist.ShowDialog();
                //MessageBox.Show("添加成功！");
                //refrashdata();
            }
            //else { MessageBox.Show("添加失败！"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string url = RestUrl.Put_toProduce;
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_Put_toProduce);
            helper.TryRequest(url);
            return;
            //PList plist = new PList();
            //plist.StartPosition = FormStartPosition.CenterScreen;
            //plist.ShowDialog();
        }

        public void NewMessageArrived()
        {
            if (this.alreadyWriteSuccess == true) return;
            string r3 = rmu900Helper.CheckWriteEpc();
            if (r3 != string.Empty)
            {
                this.alreadyWriteSuccess = true;
                AudioAlert.PlayAlert();
                Debug.WriteLine("写入标签成功 " + r3);
                addTieBiao();
            }
            string r1 = rmu900Helper.ChekcInventoryOnce();
            if (r1 != string.Empty)
            {
                Debug.WriteLine("读取到标签 " + r1);
                AudioAlert.PlayAlert();
                this.UpdateEpcList(r1);
            }
        }

        private void txtEpc_TextChanged(object sender, EventArgs e)
        {
            string Value = string.Empty;
            string txtContent = txtEpc.Text;
            lblTip.ForeColor = Color.Red;
            this.btnWriteEpc.Enabled = false;
            if (txtContent == null)
            {
                Value = "未输入EPC";

                goto SetTipValue;
            }
            if (txtContent.Length >= 0 && txtContent.Length < 24)
            {
                Value = "当前EPC长度为 " + txtContent.Length.ToString() + ",长度不符合要求";
                goto SetTipValue;

            }
            if (txtContent.Length > 24)
            {
                Value = "当前EPC长度为 " + txtContent.Length.ToString() + ",长度不符合要求";
                goto SetTipValue;
            }
            if (txtContent.Length == 24)
            {
                //Value = "当前EPC长度为 " + txtContent.Length.ToString();
                if (!Regex.IsMatch(txtContent, "[0-9a-fA-F]{24}"))
                {
                    Value = "EPC中含有不符合要求的符号";
                    goto SetTipValue;
                }

                //if (this.ctl.CheckEpcExist(txtContent))
                //{
                //    Value = "当前EPC已经使用过，请重新制定";
                //    goto SetTipValue;
                //}


                Value = "当前EPC符合要求";
                lblTip.ForeColor = Color.Black;
                this.btnWriteEpc.Enabled = true;
            }

        SetTipValue: this.lblTip.Text = Value;

            //this.btnWriteEpc.Enabled = false;

            //Isexist(this.txtEpc.Text);
        }
        void Isexist(string id)
        {
            if (id.Length <= 0)
            {
                return;
            }
            string url = RestUrl.test_isexist;
            string jsonstr = string.Empty;
            jsonstr = id;
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getresult);
            helper.TryPostData(url, jsonstr);

        }

        void helper_RequestCompleted_getresult(object o)
        {
            deleControlInvoke dele = delegate(object oO)
            {
                string back = (string)o;
                if (back == "true")
                {

                    this.btnWriteEpc.Enabled = false;
                    MessageBox.Show("编码已存在");
                    return;
                }
                else
                {
                    // 将编码写入标签

                    this.btnWriteEpc.Enabled = true;

                    //foc.addTieBiao(textBoxJD.Text, EPC);
                    //factoryOperateClass fo = new factoryOperateClass();
                    //fo.getTiebiaokList(dataGridView2, textBoxJD.Text);
                }
            };
            this.Invoke(dele, o);
        }
    }
}
