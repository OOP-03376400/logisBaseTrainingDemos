using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HFParking
{
    public partial class LoginForm : Form
    {
        private bool isMouseDown = false;
        private Point FormLocation;
        private Point mouseOffset; 
        DataColumn dc = null;
        public DataTable dt, dtall=new DataTable();
         
        public LoginForm()
        {
            InitializeComponent();
            //赋值给dc，是便于对每一个datacolumn的操作
            dc = dtall.Columns.Add("ID", Type.GetType("System.Int32"));
            dc.AutoIncrement = true;//自动增加
            dc.AutoIncrementSeed = 1;//起始为1
            dc.AutoIncrementStep = 1;//步长为1
            dc.AllowDBNull = false;//
            dc = dtall.Columns.Add("EPC", Type.GetType("System.String"));
            dc = dtall.Columns.Add("UserName", Type.GetType("System.String"));
            dc = dtall.Columns.Add("Time", Type.GetType("System.String"));
        }
        public DataTable getdt
        {
            get { return dt; }

            set { dt = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarinForm f1 = new CarinForm();
            f1.GetForm(this);
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CaroutForm cf = new CaroutForm();
            cf.GetForm(this);
            cf.Show();
        }
        public void addDt()
        {
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    DataRow dtr = dtall.NewRow();
            //    dtr[0] = dt.Rows[i]["ID"].ToString();
            //    dtr[1] = dt.Rows[i]["EPC"].ToString();
            //    dtr[2] = dt.Rows[i]["UserName"].ToString();
            //    dtr[3] = dt.Rows[i]["Time"].ToString();
            //    dtall.Rows.Add(dtr);
            //}
           // dataGridView1.DataSource = dtall;
        }
      
        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

       
      
        private void button1_MouseEnter(object sender, EventArgs e)
        {
         button1.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pictures\入口管理员选中.png");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(Application.StartupPath + @"\pictures\入口管理员.png");
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {


            if(e.Button ==MouseButtons .Left)
            {
                isMouseDown =true;
                FormLocation =this.Location;
                mouseOffset =Control.MousePosition;
            } 
        }

        private void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {


            isMouseDown =false;

 

        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {


            int _x = 0;
            int _y = 0;

            if(isMouseDown){
 Point pt =
 Control .MousePosition;

_x = mouseOffset.X - pt.X;

 _y = mouseOffset.Y - pt.Y;

         this.Location = new
               Point
                (FormLocation.X - _x, FormLocation.Y - _y);
            }

 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
