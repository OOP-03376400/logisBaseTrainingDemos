#define UDP_TRANSE
//#define SERIAL_PORT_TRANSE

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using httpHelper;
using RestAPI;
using fastJSON;
using FactorySystem;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

namespace zigbee_controler
{
    public partial class frmControler : Form
    {


        #region 类成员
#if SERIAL_PORT_TRANSE
        SerialPort comport = null;
#endif
#if UDP_TRANSE
        public Socket serverSocket;
        static byte[] byteData = new byte[1024];

#endif
        ZigbeeHelper helper = new ZigbeeHelper();
        bool bStopListening = false;
        string id = string.Empty;
        string ptemp = string.Empty;
        string phumi = string.Empty;
        bool bUdp_server_initialed = false;
        StringBuilder sbuilder = new StringBuilder();

        string current_node_id = string.Empty;
        int current_max_temp = int.MaxValue;
        int current_min_temp = int.MinValue;
        int current_max_hum = int.MaxValue;
        int current_min_hum = int.MinValue;

        int current_temp = int.MinValue;
        int current_hum = int.MinValue;

        bool bUploadZigbeeInfo = false;

        #endregion
        #region 内部函数
        public void initial_udp_server()
        {
#if UDP_TRANSE

            if (bUdp_server_initialed == true)
            {
                return;
            }
            serverSocket = new Socket(AddressFamily.InterNetwork,
                        SocketType.Dgram, ProtocolType.Udp);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndPoint = new IPEndPoint(ip, 10000);
            //Bind this address to the server
            serverSocket.Bind(ipEndPoint);
            //防止客户端强行中断造成的异常
            long IOC_IN = 0x80000000;
            long IOC_VENDOR = 0x18000000;
            long SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;

            byte[] optionInValue = { Convert.ToByte(false) };
            byte[] optionOutValue = new byte[4];
            serverSocket.IOControl((int)SIO_UDP_CONNRESET, optionInValue, optionOutValue);

            bUdp_server_initialed = true;
#endif
        }

        private void OnReceive(IAsyncResult ar)
        {
#if UDP_TRANSE

            try
            {
                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint epSender = (EndPoint)ipeSender;

                serverSocket.EndReceiveFrom(ar, ref epSender);
                if (!bStopListening)
                {
                    string temp = Encoding.UTF8.GetString(byteData);
                    MatchCollection mc = Regex.Matches(temp, @"(?i)[\da-f]{2}");
                    List<byte> buf = new List<byte>();//填充到这个临时列表中
                    //依次添加到列表中
                    foreach (Match m in mc)
                    {
                        buf.Add(Byte.Parse(m.ToString(), System.Globalization.NumberStyles.HexNumber));
                    }
                    helper.Parse(buf.ToArray());

                    Array.Clear(byteData, 0, byteData.Length);

                    //Start listening to the message send by the user
                    serverSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref epSender,
                        new AsyncCallback(OnReceive), epSender);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    string.Format("UDPServer.OnReceive  -> error = {0}"
                    , ex.Message));
            }
#endif
        }
        void HandletxtLog(int index, string nodeID, int humi, int temp)
        {

            string s1 = string.Empty;
            delZigbeeCallback dele = delegate(int _index, string _nodeID, int _humi, int _temp)
            {
                //send_info_to_server(index, nodeID, humi, temp);
                bool bChanged = false;//检查温度或者湿度是否发生了变化，只在发生变化时上传
                Debug.WriteLine(string.Format("node => {0}    humi =>  {1}    temp => {2}", _nodeID.ToString(), _humi.ToString(), _temp.ToString()));
                if (this.current_node_id == _nodeID.ToString())
                {
                    if (_humi > current_max_hum)
                    {
                        _humi = current_max_hum;
                    }
                    else
                        if (_humi < current_min_hum)
                        {
                            _humi = current_min_hum;
                        }

                    if (_temp > current_max_temp)
                    {
                        _temp = current_max_temp;
                    }
                    else if (_temp < current_min_temp)
                    {
                        _temp = current_min_temp;
                    }

                    this.lblCurrentHumunity.Text = _humi.ToString();
                    this.lblCurrentTemp.Text = _temp.ToString();
                    this.progressHumunity.Value = _humi;
                    this.progressTemp.Value = _temp;

                    if (_humi != this.current_hum || _temp != this.current_temp)
                    {
                        bChanged = true;
                    }

                    this.current_hum = _humi;
                    this.current_temp = _temp;

                    //其次检查是否要发送
                    if (bUploadZigbeeInfo == true && bChanged == true)
                    {
                        //发送到服务器
                        zigbeeInfo z = new zigbeeInfo();
                        z.node_id = _nodeID;
                        //z.startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        z.humi = _humi.ToString();
                        z.temp = _temp.ToString();
                        string jsonString = fastJSON.JSON.Instance.ToJSON(z);
                        HttpWebConnect helper = new HttpWebConnect();

                        string url = RestUrl.addZigbeeInfo;
                        helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_addzigbeeInfo);
                        helper.TryPostData(url, jsonString);
                    }
                }
                else
                    if (!this.lbNodes.Items.Contains(_nodeID) && !this.lbNotUsedNodes.Items.Contains(_nodeID))
                    {
                        //如果两个列表中均不存在该节点的ID，就添加到未使用节点列表中
                        this.lbNotUsedNodes.Items.Add(_nodeID);
                    }


            };
            this.Invoke(dele, index, nodeID, humi, temp);
        }

        public void LoadAllZigbeeNodes()
        {
            HttpWebConnect helper = new HttpWebConnect();
            string url = RestUrl.getAllZigbeeNodes;
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_LoadAllZigbeeNodes);
            helper.TryRequest(url);
        }
        void helper_RequestCompleted_LoadAllZigbeeNodes(object o)
        {
            deleControlInvoke dele = delegate(object ou)
            {
                string strUser = (string)ou;
                Debug.WriteLine(
                    string.Format("Form1.helper_RequestCompleted_getProduct-> response = {0}"
                    , strUser));
                object olist = fastJSON.JSON.Instance.ToObjectList(strUser, typeof(List<ZigbeeNode>), typeof(ZigbeeNode));

                foreach (ZigbeeNode zn in (List<ZigbeeNode>)olist)
                {
                    lbNodes.Items.Add(zn.node_id);
                }
            };
            this.Invoke(dele, o);
        }


        void helper_RequestCompleted_addzigbeeInfo(object o)
        {
            deleControlInvoke dele = delegate(object ou)
            {
                string strUser = (string)ou;
                Debug.WriteLine(
                    string.Format("Form1.helper_RequestCompleted_getProduct-> response = {0}"
                    , strUser));
                zigbeeInfo u2 = fastJSON.JSON.Instance.ToObject<zigbeeInfo>(strUser);
                if (u2.state == "ok")
                {
                    Debug.WriteLine("OK");
                }
                else
                {

                }
            };
            this.Invoke(dele, o);
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (bStopListening == true)
            {
                return;
            }
            try
            {
#if SERIAL_PORT_TRANSE
                int n = comport.BytesToRead;//n为返回的字节数
                byte[] buf = new byte[n];//初始化buf 长度为n
                comport.Read(buf, 0, n);//读取返回数据并赋值到数组
                //_RFIDHelper.Parse(buf,true);
                if (!bStopListening)
                {
                    helper.Parse(buf);
                }
#endif
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void setLED(string text)
        {
            CommandInfo c = new CommandInfo("led", text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "192.168.1.30");
            //LedInfo c = new LedInfo(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "192.168.0.98");
            string jsonString = string.Empty;
            jsonString = JSON.Instance.ToJSON(c);
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_addLedInfo);
            //string url = RestUrl.addCommandInfo;

            string url = RestUrl.addZigbeeNode;
            helper.TryPostData(url, jsonString);


        }

        void gettts(string text)
        {
            CommandInfo c = new CommandInfo("tts", text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "192.168.1.98");
            //LedInfo c = new LedInfo(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "192.168.0.98");
            string jsonString = string.Empty;
            jsonString = JSON.Instance.ToJSON(c);
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_addLedInfo);
            //string url = RestUrl.addCommandInfo;
            string url = "http://192.168.1.120:9002/index.php/" + "LED/CommandInfo/addCommandInfo";
            helper.TryPostData(url, jsonString);
        }
        void helper_RequestCompleted_addLedInfo(object o)
        {
            deleControlInvoke dele = delegate(object ou)
            {
                string strUser = (string)ou;
                Debug.WriteLine(
                    string.Format("Form1.helper_RequestCompleted_getProduct-> response = {0}"
                    , strUser));
                CommandInfo u2 = fastJSON.JSON.Instance.ToObject<CommandInfo>(strUser);
                if (u2.state == "ok")
                {

                    MessageBox.Show("更新成功！");


                }
                else
                {
                    MessageBox.Show("更新失败！");
                }
            };
            this.Invoke(dele, o);
        }

        #endregion
        public frmControler()
        {
            InitializeComponent();




            this.helper.eventZigInfo += new delZigbeeCallback(HandletxtLog);

            this.lblNodeID.Text = string.Empty;
            this.lblLocation.Text = string.Empty;
            this.lblCurrentHumunity.Text = string.Empty;
            this.lblCurrentTemp.Text = string.Empty;
            this.lblMaxHumunity.Text = string.Empty;
            this.lblMaxTemp.Text = string.Empty;
            this.lblMinHumunity.Text = string.Empty;
            this.lblMinTemp.Text = string.Empty;


            this.btnStopMonitoring.Left = this.btnStartMonitoring.Left;
            this.btnStopMonitoring.Visible = false;

            this.btnStopUpload.Left = this.btnUploadNodeInfo.Left;
            this.btnStopUpload.Visible = false;

            this.lbNodes.Items.Clear();
            this.lbNodes.SelectedIndexChanged += new EventHandler(lbNodes_SelectedIndexChanged);
            this.Shown += new EventHandler(frmControler_Shown);
            this.FormClosing += new FormClosingEventHandler(frmControler_FormClosing);
        }

        void lbNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbNodes.SelectedItem != null)
            {
                string selectedNodeID = lbNodes.SelectedItem.ToString();
                ZigbeeNode zn = new ZigbeeNode();
                zn.node_id = selectedNodeID;
                string jsonString = string.Empty;
                jsonString = JSON.Instance.ToJSON(zn);
                HttpWebConnect helper = new HttpWebConnect();
                helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getZigbeeNode);

                string url = RestUrl.getZigbeeNode;
                helper.TryPostData(url, jsonString);
            }

        }
        void helper_RequestCompleted_getZigbeeNode(object o)
        {
            deleControlInvoke dele = delegate(object ou)
            {
                string strZigbeeNode = (string)ou;
                Debug.WriteLine(
                    string.Format("Form1.helper_RequestCompleted_getZigbeeNode-> response = {0}"
                    , strZigbeeNode));
                ZigbeeNode zn = fastJSON.JSON.Instance.ToObject<ZigbeeNode>(strZigbeeNode);
                if (zn.state == "ok")
                {
                    this.lblNodeID.Text = zn.node_id;
                    this.lblLocation.Text = zn.location;
                    this.lblMaxTemp.Text = zn.max_temp;
                    this.lblMinTemp.Text = zn.min_temp;
                    this.lblMaxHumunity.Text = zn.max_humi;
                    this.lblMinHumunity.Text = zn.min_humi;

                    this.current_node_id = zn.node_id;
                    try
                    {
                        this.current_min_hum = int.Parse(zn.min_humi);
                        this.current_min_temp = int.Parse(zn.min_temp);
                        this.current_max_hum = int.Parse(zn.max_humi);
                        this.current_max_temp = int.Parse(zn.max_temp);

                        this.progressHumunity.Maximum = int.Parse(zn.max_humi);
                        this.progressHumunity.Minimum = int.Parse(zn.min_humi);
                        this.progressTemp.Maximum = int.Parse(zn.max_temp);
                        this.progressTemp.Minimum = int.Parse(zn.min_temp);

                    }
                    catch
                    {

                    }

                }
                else
                {

                }
            };
            this.Invoke(dele, o);
        }
        void frmControler_FormClosing(object sender, FormClosingEventArgs e)
        {
#if SERIAL_PORT_TRANSE
            this.comport.Close();
#endif
#if UDP_TRANSE
            if (this.serverSocket != null)
            {
                this.serverSocket.Close();
            }
#endif
        }

        void frmControler_Shown(object sender, EventArgs e)
        {
            try
            {
                //this.comport.Open();
                LoadAllZigbeeNodes();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStartMonitoring_Click(object sender, EventArgs e)
        {
            bStopListening = false;
#if SERIAL_PORT_TRANSE
            // 串口
            if (this.comport == null)
            {
                this.comport = new SerialPort();
            }
            this.comport.PortName = staticClass.serialport_name;
            this.comport.BaudRate = 19200;

            comport.DataReceived -= port_DataReceived;
            comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
#endif
#if UDP_TRANSE
            initial_udp_server();
            IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
            //The epSender identifies the incoming clients
            EndPoint epSender = (EndPoint)ipeSender;

            Array.Clear(byteData, 0, byteData.Length);

            //Start receiving data
            serverSocket.BeginReceiveFrom(byteData, 0, byteData.Length,
                SocketFlags.None, ref epSender, new AsyncCallback(OnReceive), epSender);

#endif
            this.btnStopMonitoring.Visible = true;
            this.btnStartMonitoring.Visible = false;
        }

        private void btnStopMonitoring_Click(object sender, EventArgs e)
        {
            bStopListening = true;
            bool bOk = false;
            while (!bOk)
            {
                Application.DoEvents();
                bOk = true;
                //Thread.Sleep(200);
            }
#if SERIAL_PORT_TRANSE
            this.comport.Close();
#endif
            this.btnStopMonitoring.Visible = false;
            this.btnStartMonitoring.Visible = true;
        }

        private void btnUploadNodeInfo_Click(object sender, EventArgs e)
        {
            bUploadZigbeeInfo = true;
            this.btnUploadNodeInfo.Visible = false;
            this.btnStopUpload.Visible = true;
        }

        private void btnStopUpload_Click(object sender, EventArgs e)
        {
            bUploadZigbeeInfo = false;
            this.btnStopUpload.Visible = false;
            this.btnUploadNodeInfo.Visible = true;
        }


        //private void send_info_to_server(int index, int nodeID, int humi, int temp)
        //{
        //    Debug.WriteLine(string.Format("node => {0}    humi =>  {1}    temp => {2}", nodeID.ToString(), humi.ToString(), temp.ToString()));
        //    //首先检查列表中是否已经存在
        //    if (!this.itemDic.ContainsKey(nodeID.ToString()))
        //    {
        //        this.itemDic.Add(nodeID.ToString(), true);

        //        this.checkedListBox1.Items.Add(nodeID.ToString());
        //    }
        //    //其次检查是否要发送
        //    bool bstate = this.itemDic[nodeID.ToString()];
        //    if (bstate == true)
        //    {
        //        //发送到服务器
        //        string log =
        //             string.Format("数据包号：{0} 节点ID：{1} 湿度：{2} 温度：{3}",
        //            index.ToString(),
        //            nodeID.ToString(),
        //            humi.ToString(),
        //            temp.ToString());
        //            this.appendLog(log);
        //    }
        //}

    }
}
