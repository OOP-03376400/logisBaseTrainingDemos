using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net;
using System.Text.RegularExpressions;

namespace GPS_Analysis
{
    public partial class frmSysConfig : Form
    {
        public frmSysConfig()
        {
            InitializeComponent();

            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            cmbPortName.Items.AddRange(ports);

            this.Shown += new EventHandler(frmSysConfig_Shown);
            this.FormClosing += new FormClosingEventHandler(frmSysConfig_FormClosing);
        }

        void frmSysConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        void frmSysConfig_Shown(object sender, EventArgs e)
        {
            this.cmbPortName.Text = staticClass.serialport_name;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            nsConfigDB.ConfigDB.saveConfig("serialport", this.cmbPortName.Text);
            staticClass.serialport_name = this.cmbPortName.Text;
            this.Close();
        }
    }
}
