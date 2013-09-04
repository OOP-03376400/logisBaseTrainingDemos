using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RestAPI;
using httpHelper;
using System.Diagnostics;
using fastJSON;

namespace zigbee_controler
{
    public partial class frmupdatewareHouse : Form
    {
        string EPC = string.Empty;
        public string getEPC
        {
            get { return EPC; }
            set { EPC = value; }
        }
        public frmupdatewareHouse()
        {
            InitializeComponent();
            this.Shown += new EventHandler(frmupdatewareHouse_Shown);
        }

        void frmupdatewareHouse_Shown(object sender, EventArgs e)
        {
            ZigbeeNode wH = new ZigbeeNode();
            wH.node_id =getEPC ;
            //LedInfo c = new LedInfo(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "192.168.0.98");
            string jsonString = string.Empty;
            jsonString = JSON.Instance.ToJSON(wH);
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getInfo);
            //string url = RestUrl.addCommandInfo;

            string url = RestUrl.getwareHouse;
            helper.TryPostData(url, jsonString);
        }
        void helper_RequestCompleted_getInfo(object o)
        {
            deleControlInvoke dele = delegate(object ou)
            {
                string strUser = (string)ou;
                Debug.WriteLine(
                    string.Format("Form1.helper_RequestCompleted_getProduct-> response = {0}"
                    , strUser));
                ZigbeeNode u2 = fastJSON.JSON.Instance.ToObject<ZigbeeNode>(strUser);
                if (u2.state == "ok")
                {
                     textBox2 .Text =u2.node_id ;
                     textBox3 .Text =u2.location ; 
                     textBox4.Text =u2.max_temp ;
                     textBox5 .Text =u2.min_temp ;
                     textBox7 .Text =u2.max_humi ;
                     textBox8.Text = u2.min_humi;


                }
                else
                {
                  
                }
            };
            this.Invoke(dele, o);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //ZigbeeNode wH = new ZigbeeNode(textBox3.Text, textBox2.Text, getEPC, textBox4.Text, textBox5.Text, textBox7.Text, textBox8.Text);
            //string jsonString = string.Empty;
            //jsonString = JSON.Instance.ToJSON(wH);
            //HttpWebConnect helper = new HttpWebConnect();
            //helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_addLedInfo);

            //string url = RestUrl.updatewareHouseInfo;
            //helper.TryPostData(url, jsonString);
        }
        void helper_RequestCompleted_addLedInfo(object o)
        {
            deleControlInvoke dele = delegate(object ou)
            {
                string strUser = (string)ou;
                Debug.WriteLine(
                    string.Format("Form1.helper_RequestCompleted_getProduct-> response = {0}"
                    , strUser));
                ZigbeeNode u2 = fastJSON.JSON.Instance.ToObject<ZigbeeNode>(strUser);
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
    }
}
