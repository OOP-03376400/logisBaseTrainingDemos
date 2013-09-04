using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using httpHelper;

namespace FactorySystem
{
    public partial class frmProducedList : Form
    {
        public frmProducedList()
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
            string url = RestUrl.FindProduceddata;
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
                object olist = fastJSON.JSON.Instance.ToObjectList(strProduct, typeof(List<Product>), typeof(Product));


                System.Data.DataTable dt = null;
                if (this.dv1.DataSource == null)
                {
                    dt = new System.Data.DataTable();
                    dt.Columns.Add("产品编码", typeof(string));
                    dt.Columns.Add("产品名称", typeof(string));
                    dt.Columns.Add("产品类型", typeof(string));
                    dt.Columns.Add("产品规格", typeof(string));
                    dt.Columns.Add("生产状态", typeof(string));
                    dt.Columns.Add("完成时间", typeof(string));
                    dt.Columns.Add("生产批次", typeof(string));
                    dt.Columns.Add("生产车间", typeof(string));
                    dt.Columns.Add("生产负责人", typeof(string));
                    dt.Columns.Add("联系方式", typeof(string));
                    dt.Columns.Add("生产温度", typeof(string));
                    dt.Columns.Add("生产湿度", typeof(string));
                    dt.Columns.Add("备注", typeof(string));
                }
                else
                {
                    dt = (System.Data.DataTable)dv1.DataSource;
                }
                dt.Rows.Clear();
                foreach (Product p in (List<Product>)olist)
                {
                    dt.Rows.Add(new object[]
                    {
                       p.Pro_code,p.Pro_Name,p.Pro_Leibie,p.Pro_Gui,p.Pro_state,p.finishTime,p.Pro_Pici,p.Pro_Chej,p.Pro_Person, p.Contact,p.Pro_Tempre,p.Pro_Wet, p.Remark
                    });
                }
                dv1.DataSource = dt;

                this.dv1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                int headerW = this.dv1.RowHeadersWidth;
                int columnsW = 0;
                DataGridViewColumnCollection columns = this.dv1.Columns;
                columns[0].Width = 100;
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsW += columns[i].Width;
                }
                if (columnsW + headerW < this.dv1.Width)
                {
                    int leftTotalWidht = this.dv1.Width - columnsW - headerW;
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
            refrashdata();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refrashdata();
        }

        private void chaxun_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            string url = RestUrl.indexdata;
            // Product p = new Product();
            indexinfo index = new indexinfo();
            string indexcontxt;
            indexcontxt = IndexCon1.Text;
            switch (indexcontxt)
            {
                case "产品编码":
                    index.num = 1;
                    break;
                case "产品名称":
                    index.num = 2;
                    break;
                case "产品类别":
                    index.num = 3;
                    break;
                case "生产车间":
                    index.num = 4;
                    break;
            }
            index.conditon = Condition1.Text;

            Condition1.Clear();
            string jsonstring = string.Empty;
            jsonstring = fastJSON.JSON.Instance.ToJSON(index);
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getproducingProduct);
            helper.TryPostData(url, jsonstring);
        }
    }
}
