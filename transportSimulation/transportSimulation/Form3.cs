using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using httpHelper;

namespace transportSimulation
{
    public partial class Form3 : Form
    {
        GPSPoint pointTemp = null;
        Timer timer = new Timer();
        RoadPlayer player = null;
        string currentRoadName = "";

        public Form3()
        {
            InitializeComponent();

            this.btnRestart.Enabled = false;
            this.btnRestart.Click += (o, e) =>
            {
                this.btnRestart.Enabled = false;
                this.startRunning();
            };
            this.lblCurrentRoad.Text = "未设定";
            this.lblLat.Text = "未知";
            this.lblLng.Text = "未知";

            this.btnDestnation.Text = GlobleV.Destnation;
            this.btnStartPoint.Text = GlobleV.GPS_Name;

            timer.Interval = 3000;
            timer.Tick += timer_Tick;
            this.Shown += Form3_Shown;

            this.btnRoad1.Click += Click_selectNextRoad;
            this.btnRoad2.Click += Click_selectNextRoad;

            this.FormClosing += Form3_FormClosing;

            this.btnPre.Click += (sender, e) =>
            {
                stopRunning();
                Action act = () =>
                {
                    this.Visible = false;
                    GlobleV.SecondForm.Show();
                };
                act();
            };
        }

        void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer.Tick -= timer_Tick;
            this.stopRunning();

            Application.Exit();
        }

        void Click_selectNextRoad(object sender, EventArgs e)
        {
            player.SetNextRoadName(((Button)sender).Text);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            pointTemp = player.Play(pointTemp, currentRoadName);
            if (pointTemp != null)
            {
                postjson(pointTemp.Lng, pointTemp.Lat);
            }
            //else
            //{
            //    stopRunning();
            //    postjson(0, 0, "end");
            //}
        }
        void postjson(double _lng, double _lat, string type = "sogou")
        {
            HttpWebConnect http = new HttpWebConnect();
            GPSPoint gps = new GPSPoint(_lat, _lng, GlobleV.CarID, currentRoadName, type, GlobleV.Secret);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(gps);
            http.TryPostData("http://localhost:3000/postgps", json);
        }
        void stopRunning()
        {
            this.timer.Enabled = false;
        }
        void Form3_Shown(object sender, EventArgs e)
        {
            this.startRunning();
        }

        public void startRunning()
        {
            //string serializedRoute = "[{\"RoadName\":\"road1\",\"PointList\":[{\"Lat\":1.1,\"Lng\":2.1,\"IndexInList\":0,\"RoadName\":\"road1\"},{\"Lat\":1.2,\"Lng\":2.2,\"IndexInList\":1,\"RoadName\":\"road1\"},{\"Lat\":1.3,\"Lng\":2.3,\"IndexInList\":2,\"RoadName\":\"road1\"}],\"NextRoadNameList\":[\"road2\"]},{\"RoadName\":\"road2\",\"PointList\":[{\"Lat\":2.1,\"Lng\":3.1,\"IndexInList\":0,\"RoadName\":\"road2\"},{\"Lat\":2.2,\"Lng\":3.2,\"IndexInList\":1,\"RoadName\":\"road2\"},{\"Lat\":2.3,\"Lng\":3.3,\"IndexInList\":2,\"RoadName\":\"road2\"}],\"NextRoadNameList\":[\"road3\",\"road4\"]},{\"RoadName\":\"road3\",\"PointList\":[{\"Lat\":3.1,\"Lng\":4.1,\"IndexInList\":0,\"RoadName\":\"road3\"},{\"Lat\":3.2,\"Lng\":4.2,\"IndexInList\":1,\"RoadName\":\"road3\"},{\"Lat\":3.3,\"Lng\":4.3,\"IndexInList\":2,\"RoadName\":\"road3\"}],\"NextRoadNameList\":[]},{\"RoadName\":\"road4\",\"PointList\":[{\"Lat\":4.1,\"Lng\":5.1,\"IndexInList\":0,\"RoadName\":\"road4\"},{\"Lat\":4.2,\"Lng\":5.2,\"IndexInList\":1,\"RoadName\":\"road4\"},{\"Lat\":4.3,\"Lng\":5.3,\"IndexInList\":2,\"RoadName\":\"road4\"}],\"NextRoadNameList\":[]}]";
            string serializedRoute = "[";
            serializedRoute += "{\"RoadName\":\"朝阳北路\",\"NextRoadNameList\":[\"未知道路1\",\"未知道路2\"],\"PointList\":[{\"Lat\":4827494.140625,\"Lng\":12983712.890625,\"RoadName\":\"朝阳北路\",\"IndexInList\":0},{\"Lat\":4827500,\"Lng\":12983710.9375,\"RoadName\":\"朝阳北路\",\"IndexInList\":1},{\"Lat\":4827507.8125,\"Lng\":12983207.03125,\"RoadName\":\"朝阳北路\",\"IndexInList\":2},{\"Lat\":4827511.71875,\"Lng\":12982789.0625,\"RoadName\":\"朝阳北路\",\"IndexInList\":3},{\"Lat\":4827488.28125,\"Lng\":12982417.96875,\"RoadName\":\"朝阳北路\",\"IndexInList\":4},{\"Lat\":4827406.25,\"Lng\":12982019.53125,\"RoadName\":\"朝阳北路\",\"IndexInList\":5},{\"Lat\":4827265.625,\"Lng\":12981437.5,\"RoadName\":\"朝阳北路\",\"IndexInList\":6},{\"Lat\":4827179.6875,\"Lng\":12981144.53125,\"RoadName\":\"朝阳北路\",\"IndexInList\":7}]}";
            serializedRoute += "]";
            List<RoadInfo> roads = (List<RoadInfo>)Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoadInfo>>(serializedRoute);
            Action<string, string, string> actringer = (_roadName, _lat, _lng) =>
            {
                this.lblCurrentRoad.Text = (string)_roadName;

                this.lblLat.Text = _lat;
                this.lblLng.Text = _lng;
            };
            //添加运行到关键点的事件响应
            Action<GPSPoint> ringer = _point =>
            {
                if (_point != null)
                {
                    this.currentRoadName = _point.RoadName;
                    this.Invoke(actringer, _point.RoadName, _point.Lat.ToString(), _point.Lng.ToString());

                    Debug.WriteLine(_point.FormatPointString());
                }
                else
                {
                    this.timer.Enabled = false;
                    postjson(0, 0, "end");
                    this.btnRestart.Enabled = true;

                    Debug.WriteLine("simulation end !");
                }
            };
            Action<List<string>> actRoadSelectRinger = (_roadList) =>
                {
                    this.btnRoad1.Text = "";
                    this.btnRoad2.Text = "";
                    if (_roadList.Count > 0)
                    {
                        this.btnRoad1.Text = _roadList[0];
                    }
                    if (_roadList.Count > 1)
                    {
                        this.btnRoad2.Text = _roadList[1];
                    }
                };
            //添加当该条路线有继续运行的路时的事件响应
            Action<List<string>> RoadSelectRinger = _list =>
            {
                Debug.WriteLine("选择下一条路线：");
                //打印出可以选择的道路
                foreach (string s in _list)
                {
                    Debug.WriteLine("next road => " + s);
                }

                this.Invoke(actRoadSelectRinger, _list);
            };

            player = RoadPlayer.InitializeRoadPlayer(roads, ringer, RoadSelectRinger);

            pointTemp = player.Play();
            ringer(pointTemp);

            this.timer.Enabled = true;
        }
    }
}
