using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InventoryMSystem;

namespace FactorySystem
{
    public partial class New_Mainfrm : Form
    {
        public New_Mainfrm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void menuEmployee_Click(object sender, EventArgs e)
        {
            frmTiebiao tieb = new frmTiebiao();
            tieb.StartPosition = FormStartPosition.CenterScreen;
            tieb.ShowDialog();
        }

        private void menuPopedomSet_Click(object sender, EventArgs e)
        {
            frmSysConfig protset = new frmSysConfig();
            protset.StartPosition = FormStartPosition.CenterScreen;
            protset.ShowDialog();
        }

        private void menuCompany_Click(object sender, EventArgs e)
        {
            frmProducing plist = new frmProducing();
            plist.StartPosition = FormStartPosition.CenterScreen;
            plist.ShowDialog();
        }

        private void menuCustomer_Click(object sender, EventArgs e)
        {
            frmProducedList list = new frmProducedList();
            list.StartPosition = FormStartPosition.CenterScreen;
            list.ShowDialog();
        }

    }
}
