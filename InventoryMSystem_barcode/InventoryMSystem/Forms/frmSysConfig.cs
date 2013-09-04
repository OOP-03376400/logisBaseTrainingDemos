using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net;
using UDPHelper;
using System.Text.RegularExpressions;

namespace InventoryMSystem
{
    public partial class frmSysConfig : Form, IUDPServerListener
    {
        public frmSysConfig()
        {
            InitializeComponent();

            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            cmbPortName.Items.AddRange(ports);

            this.Shown += new EventHandler(frmSysConfig_Shown);
            this.FormClosing += new FormClosingEventHandler(frmSysConfig_FormClosing);
            UDPServer.listener = this;
        }

        void frmSysConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            UDPServer.stopListening();
        }

        void frmSysConfig_Shown(object sender, EventArgs e)
        {
            this.cmbPortName.Text = staticClass.serialport_name;

            this.txtIP.Text = staticClass.restServerIP;
            this.txtPort.Text = staticClass.restServerPort;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(this.txtIP.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("IP地址设置不合法！" + ex.Message, "信息提示");
                return;
            }
            try
            {
                int port = int.Parse(this.txtPort.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("串口设置不合法！" + ex.Message, "信息提示");
                return;
            }
            nsConfigDB.ConfigDB.saveConfig("serialport", this.cmbPortName.Text);
            nsConfigDB.ConfigDB.saveConfig("restIP", this.txtIP.Text);
            nsConfigDB.ConfigDB.saveConfig("restPort", this.txtPort.Text);
            staticClass.serialport_name = this.cmbPortName.Text;
            staticClass.restServerIP = this.txtIP.Text;
            staticClass.restServerPort = this.txtPort.Text;
            this.Close();
        }

        public void new_message()
        {
            string s = UDPHelper.UDPServer.sbuilder.ToString();
            //string pattern = @"(?<key>\w{1,128})=([.\w]{0,128})";//?<key> 是为匹配的group设置别名，可以不使用索引而直接使用别名提取，如gc["address"]
            string patternConfig = @"\[web_service_config,(?<restIP>(\d{1,3}\.){3}\d{1,3}),(?<restPort>\d{1,8})\]";
            //string patternIP = @"ip=(?<value>[.\w]{0,128})";
            Match mConfig = Regex.Match(s, patternConfig);
            string IP = mConfig.Groups["restIP"].Value;
            string Port = mConfig.Groups["restPort"].Value;
            if (IP.Length > 0 && Port.Length > 0)
            {
                UDPServer.stopListening();
                deleControlInvoke dele = delegate(object oIP)
                {
                    this.txtIP.Text = oIP as string;
                };

                deleControlInvoke dele2 = delegate(object oPort)
                {
                    this.txtPort.Text = oPort as string;
                };

                this.Invoke(dele, IP);
                this.Invoke(dele2, Port);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UDPHelper.UDPServer.startUDPListening(12306);
        }
    }
}
