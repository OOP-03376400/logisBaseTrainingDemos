using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using httpHelper;
using FactorySystem.lei;


namespace FactorySystem
{
    public partial class frmProducing : Form
    {
        RestUrl newurl = new RestUrl();
        public frmProducing()
        {
            InitializeComponent();
            this.Shown += new EventHandler(data_Shown_findalldata);
        }
        void data_Shown_findalldata(object sender, EventArgs e)
        {
            this.refrashdata();
        }

        void refrashdata()
        {

            string url = RestUrl.FindProducingInfo;
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getproducingProduct);
            helper.TryRequest(url);
            return;
        }
        void helper_RequestCompleted_getproducingProduct(object o)
        {
            deleControlInvoke dele = delegate(object oProductList)
            {
                string strProduct = (string)oProductList;
                object olist = fastJSON.JSON.Instance.ToObjectList(strProduct, typeof(List<Product>), typeof(Product));//解析不出数据


                System.Data.DataTable dt = null;
                if (this.dgvProductInfo.DataSource == null)
                {
                    dt = new System.Data.DataTable();
                    dt.Columns.Add("产品编码", typeof(string));
                    dt.Columns.Add("产品名称", typeof(string));
                    dt.Columns.Add("产品类别", typeof(string));
                    dt.Columns.Add("产品规格", typeof(string));
                    dt.Columns.Add("生产状态", typeof(string));
                    dt.Columns.Add("生产批次", typeof(string));
                    dt.Columns.Add("生产车间", typeof(string));
                    dt.Columns.Add("生产负责人", typeof(string));
                    dt.Columns.Add("联系方式", typeof(string));
                    dt.Columns.Add("备注", typeof(string));
                }
                else
                {
                    dt = (System.Data.DataTable)dgvProductInfo.DataSource;
                }
                dt.Rows.Clear();
                foreach (Product p in (List<Product>)olist)
                {
                    dt.Rows.Add(new object[]
                    {
                       p.Pro_code,p.Pro_Name,p.Pro_Leibie,p.Pro_Gui,p.Pro_state,p.Pro_Pici,p.Pro_Chej,p.Pro_Person, p.Contact,p.Remark
                    });
                }
                dgvProductInfo.DataSource = dt;

                this.dgvProductInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                int headerW = this.dgvProductInfo.RowHeadersWidth;
                int columnsW = 0;
                DataGridViewColumnCollection columns = this.dgvProductInfo.Columns;
                columns[0].Width = 100;
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsW += columns[i].Width;
                }
                if (columnsW + headerW < this.dgvProductInfo.Width)
                {
                    int leftTotalWidht = this.dgvProductInfo.Width - columnsW - headerW;
                    int eachColumnAddedWidth = leftTotalWidht / (columns.Count - 1);
                    for (int i = 1; i < columns.Count; i++)
                    {
                        columns[i].Width += eachColumnAddedWidth;
                    }
                }

            };
            this.Invoke(dele, o);


        }


        private void button1_Click(object sender, EventArgs e)
        {
            frmProducedList producted = new frmProducedList();
            producted.StartPosition = FormStartPosition.CenterScreen;
            producted.ShowDialog();
        }



        public void Produce()
        {
            dgvProductInfo[4, 0].Value = "工序一";
            Process1_code.Text = dgvProductInfo[0, 0].Value.ToString();
            Process1_Product.Text = dgvProductInfo[1, 0].Value.ToString();
        }
        public void Produced(string id)
        {

            string url = RestUrl.updateProducedData;
            Product p = new Product();
            p.Pro_code = id;
            p.finishTime = DateTime.Now.ToString();
            p.Pro_Tempre = Process1_Tem.Text.ToString();
            p.Pro_Wet = Process1_Wet.Text.ToString();
            string jsonstring = string.Empty;
            jsonstring = fastJSON.JSON.Instance.ToJSON(p);
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getAllOrders);
            helper.TryPostData(url, jsonstring);


        }
        void helper_RequestCompleted_getAllOrders(object o)
        {
            string back = (string)o;
        }
        public void ClearFirtLine()
        {
            if (dgvProductInfo.Rows.Count > 0)
            {
                dgvProductInfo.Rows.RemoveAt(0);
                Process1_Product.Clear();
                Process1_code.Clear();
                //refrashdata();


            }



        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // refrashdata();
            if (dgvProductInfo.Rows.Count <= 0)
            {
                return;
            }

            if (dgvProductInfo[4, 0].Value.ToString().Trim() == "待生产")
            {
                string id = dgvProductInfo[0, 0].Value.ToString();
                Produce();


            }
            else
            {
                if (dgvProductInfo[4, 0].Value == "工序一")
                {

                    ClearFirtLine();
                    if (dgvProductInfo.Rows.Count > 0)
                    {
                        string id = dgvProductInfo[0, 0].Value.ToString();
                        Produce();


                    }

                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (dgvProductInfo.Rows.Count > 0)
            {
                if (dgvProductInfo[4, 0].Value.ToString().Trim() == "工序一")
                {
                    Produced(dgvProductInfo[0, 0].Value.ToString());
                }
            }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (dgvProductInfo.RowCount == 0)
            {
                refrashdata();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

            timer1.Enabled = false;
            timer2.Enabled = false;
            timer4.Enabled = false;
            Process1_Wet.Clear();
            Process1_Tem.Clear();
            this.btnStop.Enabled = false;
            this.btnStart.Enabled = true;
            //timer3.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer4.Enabled = true;
            //timer3.Enabled = true;
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
        }

        private void PList_Load(object sender, EventArgs e)
        {

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            string url = RestUrl.getZigbeeInfo;
            zigbeeInfo zn = new zigbeeInfo();
            zn.node_id = staticClass.zigbee_id;
            string jsonstring = fastJSON.JSON.Instance.ToJSON(zn);
            //string url = newurl.getEnviromentInfos;
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getZigbeeInfo);
            helper.TryPostData(url, jsonstring);
        }
        void helper_RequestCompleted_getZigbeeInfo(object o)
        {
            deleControlInvoke dele = delegate(object OInfo)
           {
               string Info = (string)OInfo;
               zigbeeInfo zn = fastJSON.JSON.Instance.ToObject<zigbeeInfo>(Info);
               Process1_Tem.Text = zn.temp;
               Process1_Wet.Text = zn.humi;
           };
            this.Invoke(dele, o);
        }




    }
}
