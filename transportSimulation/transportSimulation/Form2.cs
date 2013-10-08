using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace transportSimulation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            this.button1.Click += Click_showNextForm;
            this.button2.Click += Click_showNextForm;
            this.button3.Click += Click_showNextForm;
            this.button4.Click += Click_showNextForm;

            this.FormClosing += (sender, e) =>
            {
                Application.Exit();
            };

            this.btnNext.Click += (sender, e) =>
            {
                this.Visible = false;
                Form3 formNext = new Form3();
                GlobleV.ThirdForm = formNext;
                formNext.Show();
            };
            this.btnPre.Click += (sender, e) =>
            {
                GlobleV.FirstForm.Visible = true;
                GlobleV.SecondForm.Visible = false;
                
            };
            this.Shown += (sender, e) =>
            {
                GlobleV.Destnation = ((Button)button1).Text;
            };
        }

        void Click_showNextForm(object sender, EventArgs e)
        {
            GlobleV.Destnation = ((Button)sender).Text;
        }

    }
}
