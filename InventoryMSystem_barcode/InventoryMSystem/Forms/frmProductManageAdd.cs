using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Inventory;
using httpHelper;
using System.Diagnostics;
using RfidReader;
using barcode_helper;

namespace InventoryMSystem
{
    public partial class frmProductManageAdd : Form, Ibarcode_reader_listener
    {
        SerialPort comport = null;
        string tagUII = string.Empty;
        IRefreshDGV refreshForm = null;
        public frmProductManageAdd(IRefreshDGV refreshForm)
        {
            InitializeComponent();

            this.btnStop.Top = this.btnGetPID.Top;
            this.btnStop.Visible = false;

            this.refreshForm = refreshForm;

            this.dateTimePicker1.Value = DateTime.Now;
            this.FormClosing += new FormClosingEventHandler(frmProductManage_FormClosing);
            this.Shown += new EventHandler(frmProductManage_Shown);

            try
            {
                comport = new SerialPort(staticClass.serialport_name, 9600, Parity.None, 8, StopBits.One);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "异常提示！");
            }
        }

        void frmProductManage_Shown(object sender, EventArgs e)
        {
            this.fillCategary();
        }
        private void fillCategary()
        {
            HttpWebConnect helper = new HttpWebConnect();
            string url = RestUrl.allProductName;
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_disposeProductNameList);
            helper.TryRequest(url);
        }
        void helper_RequestCompleted_disposeProductNameList(object o)
        {
            string strProduct = (string)o;
            Debug.WriteLine(
             string.Format("frmProductManageAdd.helper_RequestCompleted_disposeProductNameList  -> response = {0}"
             , strProduct));
            object olist = fastJSON.JSON.Instance.ToObjectList(strProduct, typeof(List<ProductName>), typeof(ProductName));
            deleControlInvoke dele = delegate(object list)
            {
                foreach (ProductName c in (List<ProductName>)list)
                {
                    this.cmbName.Items.Add(c.name);
                    //Debug.WriteLine(c.name);
                }
            };
            this.Invoke(dele, olist);
        }
        void frmProductManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.closeSerialPort();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.closeSerialPort();

            this.Close();
        }

        private void btnGetPID_Click(object sender, EventArgs e)
        {
            //this.rmu900Helper.StartInventoryOnce();
            if (this.open_serialport() == true)
            {
                barcode_reader_helper.start(this.comport, this);
            }
            this.btnGetPID.Visible = false;
            this.btnStop.Visible = true;
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            barcode_reader_helper.stop();
            this.btnStop.Visible = false;
            this.btnGetPID.Visible = true;
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
        void UpdateStatus(string value)
        {
            if (this.statusLabel.InvokeRequired)
            {
                this.statusLabel.Invoke(new deleUpdateContorl(UpdateStatusLable), value);
            }
            else
            {
                UpdateStatusLable(value);
            }
        }

        void UpdateStatusLable(string value)
        {
            this.txtPID.Text = value;
            //this.statusLabel.Text = value;
        }
        void UpdateEPCtxtBox(object o)
        {
            deleControlInvoke dele = delegate(object oO)
            {
                string value = oO as string;
                this.txtPID.Text = value;
            };
            this.Invoke(dele, o);
        }

        private void btnSerialPortConf_Click(object sender, EventArgs e)
        {
            this.closeSerialPort();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtPID.Text == null || this.txtPID.Text == string.Empty)
            {
                MessageBox.Show("产品编号必须填写！");
                return;

            }
            if (this.cmbName.SelectedIndex == -1)
            {
                MessageBox.Show("请选择产品名称！");
                return;
            }
            Product newPro = new Product(this.txtPID.Text, this.cmbName.Text,
                                    this.dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"), this.cmbFactory.Text,
                                    this.txtComment.Text);
            string jsonString = fastJSON.JSON.Instance.ToJSON(newPro);
            Debug.WriteLine(
                string.Format("frmProductManageAdd.btnAdd_Click  -> json string = {0}"
                , jsonString));
            HttpWebConnect helper = new HttpWebConnect();
            string url = RestUrl.addProduct;
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted);
            helper.TryPostData(url, jsonString);
            return;
        }
        void helper_RequestCompleted(object o)
        {
            string strProduct = (string)o;
            Debug.WriteLine(
                string.Format("frmProductManageAdd.helper_RequestCompleted  -> response = {0}"
                , strProduct));
            Product u2 = fastJSON.JSON.Instance.ToObject<Product>(strProduct);
            deleControlInvoke dele = delegate(object op)
            {
                Product p = (Product)op;
                if (p.state == "ok")
                {
                    MessageBox.Show("添加产品信息成功！");
                    if (this.refreshForm != null)
                    {
                        this.refreshForm.refreshDGV();
                    }
                    if (this.checkBox1.Checked)
                    {
                        this.closeSerialPort();

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("添加产品信息失败！");
                }
            };
            this.Invoke(dele, u2);
        }
        private void closeSerialPort()
        {
            barcode_reader_helper.stop();
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
        public void new_message(string code)
        {
            //if (r1 != string.Empty)
            {
                //Debug.WriteLine("读取到标签 " + r1);
                AudioAlert.PlayAlert();
                this.UpdateEPCtxtBox(code);
            }
        }


    }
}
