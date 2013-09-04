using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using httpHelper;
using RestAPI;
using fastJSON;
using System.Diagnostics;

namespace zigbee_controler
{
    public partial class NodManagement : Form
    {
        int G_Int_status;
        public NodManagement()
        {
            InitializeComponent();
            this.Shown += new EventHandler(NodManagement_Shown);
            this.dgvZigbeeNodes.CellClick += new DataGridViewCellEventHandler(dgvZigbeeNodes_CellClick);
        }

        void dgvZigbeeNodes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            loadZigbeeNode(dgvZigbeeNodes.CurrentRow.Cells[0].Value.ToString());
        }

        void NodManagement_Shown(object sender, EventArgs e)
        {
            refreshDGVProductDetail();
        }
        private DataTable InitialNodeListTable()
        {
            DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("节点ID", typeof(string));
            dt.Columns.Add("位置", typeof(string));
            dt.Columns.Add("最大湿度", typeof(string));
            dt.Columns.Add("最小湿度", typeof(string));
            dt.Columns.Add("最高温度", typeof(string));
            dt.Columns.Add("最低温度", typeof(string));
            //dt.Columns.Add("状态", typeof(string));

            return dt;
        }
        void refreshDGVProductDetail()
        {
            //DataTable dt = ctlInventory.GetProductInfoTop0Table();
            //this.dgvProductInfo.DataSource = dt;

            System.Data.DataTable dt = null;
            if (this.dgvZigbeeNodes.DataSource == null)
            {
                dt = this.InitialNodeListTable();
            }
            else
            {
                dt = (System.Data.DataTable)dgvZigbeeNodes.DataSource;
            }
            dgvZigbeeNodes.DataSource = dt;


            this.dgvZigbeeNodes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dgvZigbeeNodes.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dgvZigbeeNodes.Columns;
            if (columns.Count > 0)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsW += columns[i].Width;
                }
                if (columnsW + headerW < this.dgvZigbeeNodes.Width)
                {
                    int leftTotalWidht = this.dgvZigbeeNodes.Width - columnsW - headerW;
                    int eachColumnAddedWidth = leftTotalWidht / (columns.Count);
                    for (int i = 0; i < columns.Count; i++)
                    {
                        columns[i].Width += eachColumnAddedWidth;
                    }
                }
            }
            HttpWebConnect helper = new HttpWebConnect();
            string url = RestUrl.getAllZigbeeNodes;
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getAllNodes);
            helper.TryRequest(url);
            return;
        }
        void helper_RequestCompleted_getAllNodes(object o)
        {
            deleControlInvoke dele = delegate(object oProductList)
            {
                string strProduct = (string)oProductList;
                object olist = fastJSON.JSON.Instance.ToObjectList(strProduct, typeof(List<ZigbeeNode>), typeof(ZigbeeNode));

                System.Data.DataTable dt = null;
                if (this.dgvZigbeeNodes.DataSource == null)
                {
                    dt = this.InitialNodeListTable();
                }
                else
                {
                    dt = (System.Data.DataTable)dgvZigbeeNodes.DataSource;
                }
                dt.Rows.Clear();
                foreach (ZigbeeNode u in (List<ZigbeeNode>)olist)
                {
                    dt.Rows.Add(new object[]
                    {
                        u.node_id, u.location, u.max_temp, u.min_temp, u.max_humi, u.min_humi   
                    });
                }
                dgvZigbeeNodes.DataSource = dt;

                this.dgvZigbeeNodes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                int headerW = this.dgvZigbeeNodes.RowHeadersWidth;
                int columnsW = 0;
                DataGridViewColumnCollection columns = this.dgvZigbeeNodes.Columns;
                // columns[0].Width = 50;
                for (int i = 0; i < columns.Count; i++)
                {
                    columnsW += columns[i].Width;
                }
                if (columnsW + headerW < this.dgvZigbeeNodes.Width)
                {
                    int leftTotalWidht = this.dgvZigbeeNodes.Width - columnsW - headerW;
                    int eachColumnAddedWidth = leftTotalWidht / (columns.Count - 1);
                    for (int i = 1; i < columns.Count; i++)
                    {
                        columns[i].Width += eachColumnAddedWidth;
                    }
                }
            };
            this.Invoke(dele, o);
        }

        private void toolAdd2_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            ClearControls();
            ControlStatus();
            //  this.groupBox1.Enabled = !this.groupBox1.Enabled;
            G_Int_status = 1;
        }
        public void ControlStatus()
        {
            // this.groupBox1.Enabled = !this.groupBox1.Enabled;

            //this.toolSave.Enabled = !this.toolSave.Enabled;
            //this.toolAdd2.Enabled = !this.toolAdd2.Enabled;
            //this.toolCancel.Enabled = !this.toolCancel.Enabled;
            //this.toolAmend.Enabled = !this.toolAmend.Enabled;

            //this.dgvProductInfo.Enabled = !this.dgvProductInfo.Enabled;
        }

        /// <summary>
        /// 在控件中填充选中的DataGridView控件的数据
        /// </summary>


        /// <summary>
        /// 将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            txtNodeID.Text = "";
            txtLocation.Text = "";
            txtMaxTemp.Text = "";

            txtMinTemp.Text = "";

            txtMinHumunity.Text = "";
            txtMaxHumunity.Text = "";

            //  pictureBox1.Image = Image.FromFile("");
        }

        private void toolAmend_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            ControlStatus();
            G_Int_status = 2;
            loadZigbeeNode(dgvZigbeeNodes.CurrentRow.Cells[2].Value.ToString());
        }
        void updateUserInfo()
        {
            //textBox1.Text = u2.zigBeeID;
            //textBox2.Text = u2.wareHoseID;
            //textBox3.Text = u2.shelvesID;
            //textBox4.Text = u2.uptemp;
            //textBox5.Text = u2.dowmtemp;
            //textBox7.Text = u2.uphumi;
            //textBox8.Text = u2.downhumi;


            //wareHouse U1 = new wareHouse(textBox2.Text.ToString(), this.dgvProductInfo.CurrentRow.Cells[1].Value.ToString(), textBox1.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox8.Text);
            //string jsonString = fastJSON.JSON.Instance.ToJSON(U1);
            //HttpWebConnect helper = new HttpWebConnect();
            //helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getProduct);
            //string url = RestUrl.updatewareHouseInfo ;
            //helper.TryPostData(url, jsonString);
        }

        void helper_RequestCompleted_getProduct(object o)
        {
            deleControlInvoke dele = delegate(object ou)
            {
                string strUser = (string)ou;
                Debug.WriteLine(
                    string.Format("Form1.helper_RequestCompleted_getProduct-> response = {0}"
                    , strUser));
                ZigbeeNode u2 = fastJSON.JSON.Instance.ToObject<ZigbeeNode>(strUser);
                if (u2.state == "ok")
                {
                    MessageBox.Show("更新成功！");
                    //groupBox1.Enabled = false;
                    ControlStatus();
                    ClearControls();
                    //  pictureBox1.Image = Image.FromFile(path2 + PicturePath + u2.userPic);
                    //  pictureBox1.Image = Image.FromFile(u2.userPic);
                }
                else
                {
                    MessageBox.Show("更新失败！");
                }
            };
            this.Invoke(dele, o);


            //updateUserForm uuf = new updateUserForm();

            //uuf.ShowDialog();
        }

        void loadZigbeeNode(string id)
        {

            ZigbeeNode zn = new ZigbeeNode();
            zn.node_id = id;
            //LedInfo c = new LedInfo(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "192.168.0.98");
            string jsonString = string.Empty;
            jsonString = JSON.Instance.ToJSON(zn);
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_getZigbeeNode);
            //string url = RestUrl.addCommandInfo;

            string url = RestUrl.getZigbeeNode;
            helper.TryPostData(url, jsonString);
        }
        void helper_RequestCompleted_getZigbeeNode(object o)
        {
            deleControlInvoke dele = delegate(object ou)
            {
                string strZigbeeNode = (string)ou;
                Debug.WriteLine(
                    string.Format("Form1.helper_RequestCompleted_getZigbeeNode-> response = {0}"
                    , strZigbeeNode));
                ZigbeeNode u2 = fastJSON.JSON.Instance.ToObject<ZigbeeNode>(strZigbeeNode);
                if (u2.state == "ok")
                {
                    txtNodeID.Text = u2.node_id;
                    txtLocation.Text = u2.location;
                    txtMaxTemp.Text = u2.max_temp;
                    txtMinTemp.Text = u2.min_temp;
                    txtMaxHumunity.Text = u2.max_humi;
                    txtMinHumunity.Text = u2.min_humi;
                }
                else
                {

                }
            };
            this.Invoke(dele, o);
        }

        private void dgvProductInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            loadZigbeeNode(dgvZigbeeNodes.CurrentRow.Cells[2].Value.ToString());
        }

        private void toolCancel_Click(object sender, EventArgs e)
        {
            //groupBox1.Enabled = false;
            ControlStatus();
            ClearControls();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            switch (G_Int_status)
            {
                case 1:
                    //下面是要执行的SQL语句
                    addWarehouseInfo();
                    break;
                case 2:
                    updateUserInfo();
                    break;
                default:
                    break;
            }
        }
        void addWarehouseInfo()
        {
            //wareHouse wH = new wareHouse(textBox3.Text, textBox2.Text, textBox1.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox8.Text);
            //string jsonString = string.Empty;
            //jsonString = JSON.Instance.ToJSON(wH);
            //HttpWebConnect helper = new HttpWebConnect();
            //helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_addLedInfo);

            //string url = RestUrl.addwareHouseInfo;
            //helper.TryPostData(url, jsonString);
        }
        void helper_RequestCompleted_addLedInfo(object o)
        {
            deleControlInvoke dele = delegate(object ou)
            {
                string strUser = (string)ou;
                Debug.WriteLine(
                    string.Format("Form1.helper_RequestCompleted_getProduct-> response = {0}"
                    , strUser));
                ZigbeeNode u2 = fastJSON.JSON.Instance.ToObject<ZigbeeNode>(strUser);
                if (u2.state == "ok")
                {

                    MessageBox.Show("更新成功！");
                    //groupBox1.Enabled = false;
                    ControlStatus();
                    ClearControls();
                    refreshDGVProductDetail();

                }
                else
                {
                    MessageBox.Show("更新失败！");
                }
            };
            this.Invoke(dele, o);
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            //ZigbeeNode w = new ZigbeeNode();
            //w.location = dgvProductInfo.CurrentRow.Cells[1].Value.ToString();
            //string jsonString = string.Empty;
            //jsonString = JSON.Instance.ToJSON(w);
            //HttpWebConnect helper = new HttpWebConnect();
            //helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_delLedInfo);

            //string url = RestUrl.deletewareHouse;
            //helper.TryPostData(url, jsonString);
        }
        void helper_RequestCompleted_delLedInfo(object o)
        {
            deleControlInvoke dele = delegate(object ou)
            {
                string strUser = (string)ou;
                Debug.WriteLine(
                    string.Format("Form1.helper_RequestCompleted_getProduct-> response = {0}"
                    , strUser));
                ZigbeeNode u2 = fastJSON.JSON.Instance.ToObject<ZigbeeNode>(strUser);
                if (u2.state == "ok")
                {

                    MessageBox.Show("更新成功！");

                    refreshDGVProductDetail();
                }
                else
                {
                    MessageBox.Show("更新失败！");
                }
            };
            this.Invoke(dele, o);
        }

        private void toolrefesh_Click(object sender, EventArgs e)
        {
            refreshDGVProductDetail();
        }

        private void toolExit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtNodeID.Text.Length <= 0)
            {
                MessageBox.Show("请填写有效的节点ID！", "信息提示");
                return;
            }
            if (this.txtMaxTemp.Value < this.txtMinTemp.Value)
            {
                MessageBox.Show("最高温度小于最低温度！", "信息提示");
                return;
            }
            if (this.txtMaxHumunity.Value < this.txtMinHumunity.Value)
            {
                MessageBox.Show("最大湿度小于最小温度！", "信息提示");
                return;
            }

            ZigbeeNode zn = new ZigbeeNode(this.txtNodeID.Text,
                                            this.txtLocation.Text,
                                            this.txtMaxTemp.Value.ToString(), this.txtMinTemp.Value.ToString(),
                                            this.txtMaxHumunity.Value.ToString(), this.txtMinHumunity.Value.ToString());
            string jsonString = string.Empty;
            jsonString = JSON.Instance.ToJSON(zn);
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_addZigbeeNodeInfo);

            string url = RestUrl.addZigbeeNode;
            helper.TryPostData(url, jsonString);
        }
        void helper_RequestCompleted_addZigbeeNodeInfo(object o)
        {
            deleControlInvoke dele = delegate(object ou)
            {
                string strZigbeeNode = (string)ou;
                Debug.WriteLine(
                    string.Format("Form1.helper_RequestCompleted_addZigbeeNodeInfo-> response = {0}"
                    , strZigbeeNode));
                ZigbeeNode u2 = fastJSON.JSON.Instance.ToObject<ZigbeeNode>(strZigbeeNode);
                if (u2.state == "ok")
                {

                    MessageBox.Show("更新成功！");
                    refreshDGVProductDetail();

                }
                else
                {
                    MessageBox.Show("更新失败！");
                }
            };
            this.Invoke(dele, o);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtNodeID.Text.Length <= 0)
            {
                MessageBox.Show("请选择要删除的节点！", "信息提示");
                return;
            }
            ZigbeeNode zn = new ZigbeeNode();
            zn.node_id = this.txtNodeID.Text;
            string jsonString = string.Empty;
            jsonString = JSON.Instance.ToJSON(zn);
            HttpWebConnect helper = new HttpWebConnect();
            helper.RequestCompleted += new deleGetRequestObject(helper_RequestCompleted_deleteZigbeeNodeInfo);

            string url = RestUrl.deleteZigbeeNode;
            helper.TryPostData(url, jsonString);
        }
        void helper_RequestCompleted_deleteZigbeeNodeInfo(object o)
        {
            deleControlInvoke dele = delegate(object ou)
            {
                string strZigbeeNode = (string)ou;
                Debug.WriteLine(
                    string.Format("Form1.helper_RequestCompleted_deleteZigbeeNodeInfo-> response = {0}"
                    , strZigbeeNode));
                ZigbeeNode u2 = fastJSON.JSON.Instance.ToObject<ZigbeeNode>(strZigbeeNode);
                if (u2.state == "ok")
                {

                    MessageBox.Show("删除成功！");
                    refreshDGVProductDetail();

                }
                else
                {
                    MessageBox.Show("删除出现异常！");
                }
            };
            this.Invoke(dele, o);
        }

    }
}
