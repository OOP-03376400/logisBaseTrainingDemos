using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using fastJSON;
using httpHelper;
using RestAPI;
using System.Diagnostics;

namespace zigbee_controler
{
    public partial class frmwareHouseBD : Form
    {

        string EPC = string.Empty;
        public string getEPC
        {
            get { return EPC; }
            set { EPC = value; }
        }
        public frmwareHouseBD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ZigbeeNode wH = new ZigbeeNode(textBox3.Text ,textBox2.Text ,getEPC ,textBox4.Text ,textBox5.Text ,textBox7.Text ,textBox8.Text );
            //string jsonString = string.Empty;
            //jsonString = JSON.Instance.ToJSON(wH);
            //HttpWebConnect helper = new HttpWebConnect();
            //helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_addLedInfo);

            //string url = RestUrl.addwareHouseInfo;
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
                    frmControler f = (frmControler)this.Tag;
                    f.LoadAllZigbeeNodes();

                    MessageBox.Show("更新成功！");
                 


                }
                else
                {
                    MessageBox.Show("更新失败！");
                
                }
            };
            this.Invoke(dele, o);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
