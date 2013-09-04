using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Inventory;
using httpHelper;
using RfidReader;
using System.IO.Ports;
using barcode_helper;

namespace InventoryMSystem
{
    public partial class frmStorageManage : Form, Ibarcode_reader_listener
    {
        bool bGettingTag = false;//是否正在获取标签
        SerialPort comport = null;

        public frmStorageManage()
        {
            InitializeComponent();
            this.Shown += new EventHandler(frmStorageManage_Shown);
            this.tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
            this.dgvNotStoragedPInfo.CellContentClick += new DataGridViewCellEventHandler(dgvNotStoragedPInfo_CellContentClick);


            this.FormClosing += new FormClosingEventHandler(frmStorageManage_FormClosing);

            try
            {
                comport = new SerialPort(staticClass.serialport_name, 9600, Parity.None, 8, StopBits.One);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "异常提示！");
            }
        }

        string __lastTagTimeStamp = string.Empty;
        //定时获取扫描到的标签
        void __timer_Tick(object sender, EventArgs e)
        {
            scanTagPara para = new scanTagPara(InventoryCommand.扫描入库, this.__lastTagTimeStamp);
            string jsonString = fastJSON.JSON.Instance.ToJSON(para);
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getScanTags);
            string url = RestUrl.getScanedTags;
            helper.TryPostData(url, jsonString);
        }
        void helper_RequestCompleted_getScanTags(object o)
        {
            string strTags = (string)o;
            Debug.WriteLine(
                string.Format("frmStorageManage.helper_RequestCompleted_getScanTags  ->  = {0}"
                , strTags));
            object olist = fastJSON.JSON.Instance.ToObjectList(strTags, typeof(List<tagID>), typeof(tagID));
            deleControlInvoke dele = delegate(object ol)
            {
                List<tagID> tagList = (List<tagID>)ol;
                if (tagList.Count > 0)
                {
                    tagID t = tagList[tagList.Count - 1];
                    this.__lastTagTimeStamp = t.startTime;
                    for (int i = 0; i < tagList.Count; i++)
                    {
                        tagID temp = tagList[i];
                        LinkEPCToProduct(temp.tag);
                    }
                }
            };
            this.Invoke(dele, olist);
        }


        void frmStorageManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.closeSerialPort();
        }

        void dgvStoragedP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    DataGridViewRowCollection rows = this.dgvStoragedP.Rows;
            //    DataGridViewRow row = rows[e.RowIndex];
            //    DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)row.Cells[0];
            //    if ((string)cbc.Value == Boolean.FalseString)
            //    {
            //        cbc.Value = Boolean.TrueString;
            //    }
            //    else
            //    {
            //        cbc.Value = Boolean.FalseString;
            //    }
            //}
        }

        void dgvNotStoragedPInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRowCollection rows = this.dgvNotStoragedPInfo.Rows;
                DataGridViewRow row = rows[e.RowIndex];
                DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)row.Cells[0];
                if ((string)cbc.Value == Boolean.FalseString)
                {
                    cbc.Value = Boolean.TrueString;
                }
                else
                {
                    cbc.Value = Boolean.FalseString;
                }
            }
        }

        void LinkEPCToProduct(object o)
        {

            deleControlInvoke dele = delegate(object oEpc)
            {
                string epc = oEpc as string;
                DataGridViewRowCollection rows = this.dgvNotStoragedPInfo.Rows;
                foreach (DataGridViewRow vr in rows)
                {
                    DataGridViewCell cepc = (DataGridViewCell)vr.Cells[1];
                    if (((string)cepc.Value) == epc)
                    {
                        DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                        if (cbc.Value == null || ((string)cbc.Value) == Boolean.FalseString)
                        {
                            cbc.Value = Boolean.TrueString;
                            AudioAlert.PlayAlert();
                        }

                        break;
                    }
                }
            };
            this.Invoke(dele, o);
        }
        void frmStorageManage_Shown(object sender, EventArgs e)
        {
            this.RefreshNotStoragedPInfo();
        }

        void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0)
            {
                this.RefreshNotStoragedPInfo();
            }
            else
            {
                RefreshStoragedPInfo();

            }
        }
        public void RefreshStoragedPInfo()
        {
            //this.cbSelectAllStoragedP.Checked = false;

            //DataTable table = null;
            //table = ctl.GetInStorageProductInfoTable();
            //this.dgvStoragedP.DataSource = table;
            //if (!this.dgvStoragedP.Columns.Contains("checkColumn"))
            //{
            //    DataGridViewCheckBoxColumn cc = new DataGridViewCheckBoxColumn();
            //    cc.HeaderText = "";
            //    cc.Name = "checkColumn";
            //    cc.Width = 30;
            //    dgvStoragedP.Columns.Insert(0, cc);
            //}
            //this.dgvStoragedP.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //int headerW = this.dgvStoragedP.RowHeadersWidth;
            //int columnsW = 0;
            //DataGridViewColumnCollection columns = this.dgvStoragedP.Columns;
            //columns[0].Width = 50;
            //for (int i = 0; i < columns.Count; i++)
            //{
            //    columnsW += columns[i].Width;
            //}
            //if (columnsW + headerW < this.dgvStoragedP.Width)
            //{
            //    int leftTotalWidht = this.dgvStoragedP.Width - columnsW - headerW;
            //    int eachColumnAddedWidth = leftTotalWidht / (columns.Count - 1);
            //    for (int i = 1; i < columns.Count; i++)
            //    {
            //        columns[i].Width += eachColumnAddedWidth;
            //    }
            //}

        }
        void helper_RequestCompleted_getPreProListToStorage(object o)
        {
            deleControlInvoke dele = delegate(object oProductList)
            {
                string strProduct = (string)oProductList;
                Debug.WriteLine(
                    string.Format("frmStorageManage.helper_RequestCompleted_disposeList  ->  = {0}"
                    , strProduct));
                object olist = fastJSON.JSON.Instance.ToObjectList(strProduct, typeof(List<Product>), typeof(Product));

                DataTable dt = null;
                if (this.dgvNotStoragedPInfo.DataSource == null)
                {
                    dt = new DataTable();
                    dt.Columns.Add("产品编号", typeof(string));
                    dt.Columns.Add("产品名称", typeof(string));
                    dt.Columns.Add("生产日期", typeof(string));
                    dt.Columns.Add("产品类别", typeof(string));
                    dt.Columns.Add("产品备注信息", typeof(string));
                }
                else
                {
                    dt = (DataTable)dgvNotStoragedPInfo.DataSource;
                }
                dt.Rows.Clear();
                foreach (Product p in (List<Product>)olist)
                {
                    dt.Rows.Add(new object[]{
                        p.productID,
                        p.productName,
                        p.produceDate,
                        p.productCategory,
                        p.descript
                    });
                }
                dgvNotStoragedPInfo.DataSource = dt;

                if (!this.dgvNotStoragedPInfo.Columns.Contains("checkColumn"))
                {
                    DataGridViewCheckBoxColumn cc = new DataGridViewCheckBoxColumn();
                    cc.HeaderText = "";
                    cc.Name = "checkColumn";
                    cc.Width = 50;
                    dgvNotStoragedPInfo.Columns.Insert(0, cc);
                }

                this.dgvNotStoragedPInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                int headerW = this.dgvNotStoragedPInfo.RowHeadersWidth;
                int columnsW = 0;
                DataGridViewColumnCollection columns = this.dgvNotStoragedPInfo.Columns;
                columns[0].Width = 50;
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsW += columns[i].Width;
                }
                if (columnsW + headerW < this.dgvNotStoragedPInfo.Width)
                {
                    int leftTotalWidht = this.dgvNotStoragedPInfo.Width - columnsW - headerW;
                    int eachColumnAddedWidth = leftTotalWidht / (columns.Count - 1);
                    for (int i = 1; i < columns.Count; i++)
                    {
                        columns[i].Width += eachColumnAddedWidth;
                    }
                }
            };
            this.Invoke(dele, o);
        }
        public void RefreshNotStoragedPInfo()
        {
            DataTable dt = null;
            if (this.dgvNotStoragedPInfo.DataSource == null)
            {
                dt = new DataTable();
                dt.Columns.Add("产品编号", typeof(string));
                dt.Columns.Add("产品名称", typeof(string));
                dt.Columns.Add("生产日期", typeof(string));
                dt.Columns.Add("产品类别", typeof(string));
                dt.Columns.Add("产品备注信息", typeof(string));
            }
            else
            {
                dt = (DataTable)dgvNotStoragedPInfo.DataSource;
            }
            dgvNotStoragedPInfo.DataSource = dt;
            if (!this.dgvNotStoragedPInfo.Columns.Contains("checkColumn"))
            {
                DataGridViewCheckBoxColumn cc = new DataGridViewCheckBoxColumn();
                cc.HeaderText = "";
                cc.Name = "checkColumn";
                cc.Width = 50;
                dgvNotStoragedPInfo.Columns.Insert(0, cc);
            }

            this.dgvNotStoragedPInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dgvNotStoragedPInfo.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dgvNotStoragedPInfo.Columns;
            columns[0].Width = 50;
            for (int i = 0; i < columns.Count; i++)
            {
                columnsW += columns[i].Width;
            }
            if (columnsW + headerW < this.dgvNotStoragedPInfo.Width)
            {
                int leftTotalWidht = this.dgvNotStoragedPInfo.Width - columnsW - headerW;
                int eachColumnAddedWidth = leftTotalWidht / (columns.Count - 1);
                for (int i = 1; i < columns.Count; i++)
                {
                    columns[i].Width += eachColumnAddedWidth;
                }
            }

            HttpWebConnect helper = new HttpWebConnect();
            string url = RestUrl.getPreProListToStorage;
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getPreProListToStorage);
            helper.TryRequest(url);
            return;

            //this.cbSelectAllNotStoragedP.Checked = false;
            //DataTable table = null;

            //table = ctl.GetNotInStorageProductInfoTable();
            //this.dgvNotStoragedPInfo.DataSource = table;

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
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.closeSerialPort();
            this.Close();
        }

        private void btnGetTag_Click(object sender, EventArgs e)
        {
            if (this.bGettingTag)
            {
                this.bGettingTag = false;
                this.btnGetTag.Text = "扫描";
                //停止通过网络获取标签

                //本地扫描标签，不通过网络
                //this.rmu900Helper.StopInventory();
                barcode_reader_helper.stop();

            }
            else
            {
                this.bGettingTag = true;
                this.btnGetTag.Text = "停止";
                //开始通过网络获取标签

                //本地扫描标签，不通过网络
                if (this.open_serialport() == true)
                {
                    barcode_reader_helper.start(this.comport, this);
                }
                //this.rmu900Helper.StartInventory();
            }
        }
        bool open_serialport()
        {
            bool bR = true;
            try
            {
                if (this.comport == null)
                {
                    this.comport = new SerialPort(staticClass.serialport_name);
                }
                // 设置串口参数
                if (!comport.IsOpen)
                {
                    comport.Open();//尝试打开串口
                }
            }
            catch (Exception ex)//进行异常捕获
            {
                MessageBox.Show(ex.Message);
                bR = false;
            }
            return bR;
        }
        private void btnStorageP_Click(object sender, EventArgs e)
        {
            List<Product> list = new List<Product>();
            DataGridViewRowCollection rows = this.dgvNotStoragedPInfo.Rows;
            foreach (DataGridViewRow vr in rows)
            {
                DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                if ((string)cbc.Value == Boolean.TrueString)
                {
                    DataGridViewCell cepc = (DataGridViewCell)vr.Cells[1];
                    string epc = (string)cepc.Value;
                    Product p = new Product(epc, string.Empty, string.Empty, string.Empty, string.Empty);
                    list.Add(p);
                    //ctl.SetProductInStorage(epc);
                }
            }
            string jsonString = fastJSON.JSON.Instance.ToJSON(list);
            Debug.WriteLine(
                string.Format("frmStorageManage.btnStorageP_Click  ->  = {0}"
                , jsonString));
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_addProductToStorage);
            string url = RestUrl.addProductToStorage;
            helper.TryPostData(url, jsonString);

            return;

        }
        void helper_RequestCompleted_addProductToStorage(object o)
        {

            string strProducts = (string)o;
            Debug.WriteLine(
                string.Format("frmStorageManage.helper_RequestCompleted_addProductToStorage  ->  = {0}"
                , strProducts));
            object olist = fastJSON.JSON.Instance.ToObjectList(strProducts, typeof(List<Product>), typeof(Product));
            deleControlInvoke dele = delegate(object ol)
            {
                foreach (Product c in (List<Product>)olist)
                {
                    Debug.WriteLine(c.productID + "      " + c.productName + "     " + c.state);
                }
                this.RefreshNotStoragedPInfo();
            };
            this.Invoke(dele, olist);
        }

        private void cbSelectAllNotStoragedP_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewRowCollection rows = this.dgvNotStoragedPInfo.Rows;
            if (this.cbSelectAllNotStoragedP.Checked)
            {
                foreach (DataGridViewRow vr in rows)
                {
                    DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                    cbc.Value = Boolean.TrueString;

                }
            }
            else
            {
                foreach (DataGridViewRow vr in rows)
                {
                    DataGridViewCheckBoxCell cbc = (DataGridViewCheckBoxCell)vr.Cells[0];
                    cbc.Value = Boolean.FalseString;
                }
            }
        }

        private void btnRefreshNotStoragedP_Click(object sender, EventArgs e)
        {
            this.RefreshNotStoragedPInfo();
        }

        private void btnRefreshStoragedP_Click(object sender, EventArgs e)
        {
            this.RefreshStoragedPInfo();
        }
        public void new_message(string code)
        {
            //string r2 = rmu900Helper.CheckInventory();
            //if (r2 != string.Empty)
            //{
            //    Debug.WriteLine("读取到标签 " + r2);
            AudioAlert.PlayAlert();
            this.LinkEPCToProduct(code);
            //}
        }
    }
}
