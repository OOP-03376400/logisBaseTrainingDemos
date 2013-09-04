using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GPS_Analysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 数据采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GPSA frm = new GPSA();
            frm.ShowDialog();
        }

        private void 配置CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSysConfig frm = new frmSysConfig();
            frm.ShowDialog();
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
