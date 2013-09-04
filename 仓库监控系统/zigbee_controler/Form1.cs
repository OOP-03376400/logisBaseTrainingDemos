using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace zigbee_controler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 系统参数SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSysConfig frm = new frmSysConfig();
            //frm.MdiParent = this;
            //frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void 打开SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmControler frm = new frmControler();
            //frm.MdiParent = this;
            //frm.StartPosition = FormStartPosition.CenterParent;

            frm.ShowDialog ();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NodManagement n = new NodManagement();
            //n.MdiParent = this;
            //n.StartPosition = FormStartPosition.CenterParent;
            n.Show();
        }

        private void 结点管理NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NodManagement n = new NodManagement();
            //n.MdiParent = this;
            //n.StartPosition = FormStartPosition.CenterParent;
            n.Show();
        }
    }
}
