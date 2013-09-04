using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using nsConfigDB;

namespace InventoryMSystem
{
    public partial class frmSysSetting : Form
    {
        public frmSysSetting()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmSysSetting_Load);
        }

        void frmSysSetting_Load(object sender, EventArgs e)
        {
            this.txtIP.Text = staticClass.ip;
            this.txtPort.Text = staticClass.tcp_port.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool checkValidation()
        {
            bool bR = true;
            int tcpPort = 5000;
            try
            {
                tcpPort = int.Parse(this.txtPort.Text);

            }
            catch 
            {
                MessageBox.Show("端口设置不正确，请重新设置！");
                return false;
            }
            string ip = string.Empty;
            try
            {
                ip = txtIP.Text;
                IPAddress address = IPAddress.Parse(ip);
            }
            catch 
            {
                MessageBox.Show("IP设置不正确，请重新设置！");
                return false;
            }
            return bR;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.checkValidation())
            {
                //string portName = this.cmbPortName.Text;
                string ip = this.txtIP.Text;
                string tcpPort = this.txtPort.Text;
                //ConfigDB.saveConfig("comportName", portName);
                ConfigDB.saveConfig("ip", ip);
                ConfigDB.saveConfig("tcp_port", tcpPort);

                staticClass.ip = ip;
                //sysConfig.comportName = portName;
                staticClass.tcp_port = int.Parse(tcpPort);

                this.Close();
            }
        }
    }
}
