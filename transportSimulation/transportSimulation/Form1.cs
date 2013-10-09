using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using httpHelper;
using MetroFramework.Forms;

namespace transportSimulation
{
    public partial class Form1 : Form
    {
        bool bGetCarID = true;
        bool bGetGPS = false;

        Timer timer = null;
        public Form1()
        {
            InitializeComponent();

            this.btnNext.Enabled = false;
            this.btnNext.Click += (sender, e) =>
            {
                this.Visible = false;
                Form2 formNext = new Form2();
                GlobleV.SecondForm = formNext;
                formNext.Show();
            };

            this.btnGetGPS.Enabled = false;
            this.lbl1.Visible = false;
            this.lbl2.Visible = false;
            this.lblLat.Visible = false;
            this.lblLng.Visible = false;


            this.btnGetGPS.Click += (sender, e) =>
            {
                GlobleV.GPS_Name = "定位点";

                GlobleV.Lat = this.lblLat.Text;
                GlobleV.Lng = this.lblLng.Text;

                this.bGetGPS = true;
                SetNextButton();
            };
            this.btnDefaultGPS.Click += (sender, e) =>
            {
                GlobleV.GPS_Name = "学校";

                GlobleV.Lat = this.lblLatInternal.Text;
                GlobleV.Lng = this.lblLngInternal.Text;

                bGetGPS = true;
                SetNextButton();
            };

            timer = new Timer();
            timer.Interval = 10000;
            timer.Tick += (sender, e) =>
            {
                timer.Enabled = false;
                Action act = () =>
                {
                    this.btnGetGPS.Enabled = true;
                    this.btnGetGPS.Text = "定位完成";
                    this.lbl1.Visible = true;
                    this.lbl2.Visible = true;
                    this.lblLng.Text = "116.1";
                    this.lblLat.Text = "39.5";
                    this.lblLat.Visible = true;
                    this.lblLng.Visible = true;
                };
                this.Invoke(act);
            };
            timer.Enabled = true;
        }

        void postjson()
        {
            HttpWebConnect http = new HttpWebConnect();
            GPSPoint gps = new GPSPoint(4827636.71875, 12983703.125, "11");
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(gps);
            http.TryPostData("http://localhost:3000/postRawGPS", json);
        }
        void SetNextButton()
        {
            Action act = () =>
            {
                if (bGetGPS && bGetCarID)
                {
                    this.btnNext.Enabled = true;
                }
                else
                {
                    this.btnNext.Enabled = false;
                }
            };
            if (this.InvokeRequired)
            {
                this.Invoke(act);
            }
            else
            {
                act();
            }
        }
        void btnGetGPS_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            postjson();
        }
    }
}
