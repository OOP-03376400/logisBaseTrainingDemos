using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace transportSimulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //InitialCarList(4, this.Width, 40, 40);
        }

        //void InitialCarList(int count, int totalWidth, int carboxWidth, int carboxHeight)
        //{
        //    //int totalWidth = this.Width;
        //    int leftFrame = (totalWidth - carboxWidth * count - carboxWidth / 2 * (count - 1)) / 2;
        //    for (int i = 0; i < count - 1; i++)
        //    {
        //        Button b = CreateNewCarBox(leftFrame, 50);
        //        b.Text = "Car" + i.ToString();
        //    }
        //}

        //Button CreateNewCarBox(int left, int top)
        //{
            //Button button1;
            //button1 = new System.Windows.Forms.Button();
            //// 
            //// button1
            //// 
            //button1.Location = new System.Drawing.Point(left, top);
            //button1.Name = "button1";
            //button1.Size = new System.Drawing.Size(82, 48);
            //button1.TabIndex = 0;
            //button1.Text = "button1";
            //button1.UseVisualStyleBackColor = true;

            //Controls.Add(this.button1);

            //return button1;
        //}
    }
}
