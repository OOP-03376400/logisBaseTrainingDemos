using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using transportSimulation;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        // Json 数据格式
        // [{"RoadName":"road1","PointList":[{"Lat":1.1,"Lng":2.1,"IndexInList":0,"RoadName":"road1"},{"Lat":1.2,"Lng":2.2,"IndexInList":1,"RoadName":"road1"},{"Lat":1.3,"Lng":2.3,"IndexInList":2,"RoadName":"road1"}],"NextRoadNameList":["road2"]},{"RoadName":"road2","PointList":[{"Lat":2.1,"Lng":3.1,"IndexInList":0,"RoadName":"road2"},{"Lat":2.2,"Lng":3.2,"IndexInList":1,"RoadName":"road2"},{"Lat":2.3,"Lng":3.3,"IndexInList":2,"RoadName":"road2"}],"NextRoadNameList":["road3","road4"]},{"RoadName":"road3","PointList":[{"Lat":3.1,"Lng":4.1,"IndexInList":0,"RoadName":"road3"},{"Lat":3.2,"Lng":4.2,"IndexInList":1,"RoadName":"road3"},{"Lat":3.3,"Lng":4.3,"IndexInList":2,"RoadName":"road3"}],"NextRoadNameList":[]},{"RoadName":"road4","PointList":[{"Lat":4.1,"Lng":5.1,"IndexInList":0,"RoadName":"road4"},{"Lat":4.2,"Lng":5.2,"IndexInList":1,"RoadName":"road4"},{"Lat":4.3,"Lng":5.3,"IndexInList":2,"RoadName":"road4"}],"NextRoadNameList":[]}]
        [TestMethod]
        public void exportJsonRoute()
        {
            //初始化一条路线,是由多条路组成的
            List<RoadInfo> route = new List<RoadInfo>();

            //初始化一条路,并为其添加一些关键点
            RoadInfo road1 = new RoadInfo("road1");
            GPSPoint p11 = new GPSPoint(1.1, 2.1);
            GPSPoint p12 = new GPSPoint(1.2, 2.2);
            GPSPoint p13 = new GPSPoint(1.3, 2.3);
            road1.AddPoint(p11);
            road1.AddPoint(p12);
            road1.AddPoint(p13);

            road1.AddNextRoadName("road2");
            route.Add(road1);

            RoadInfo road2 = new RoadInfo("road2");
            GPSPoint p21 = new GPSPoint(2.1, 3.1);
            GPSPoint p22 = new GPSPoint(2.2, 3.2);
            GPSPoint p23 = new GPSPoint(2.3, 3.3);
            road2.AddPoint(p21);
            road2.AddPoint(p22);
            road2.AddPoint(p23);

            //为该条路添加可以选择的路
            road2.AddNextRoadName("road3");
            road2.AddNextRoadName("road4");

            route.Add(road2);

            RoadInfo road3 = new RoadInfo("road3");
            GPSPoint p31 = new GPSPoint(3.1, 4.1);
            GPSPoint p32 = new GPSPoint(3.2, 4.2);
            GPSPoint p33 = new GPSPoint(3.3, 4.3);


            road3.AddPoint(p31);
            road3.AddPoint(p32);
            road3.AddPoint(p33);

            route.Add(road3);


            RoadInfo road4 = new RoadInfo("road4");
            GPSPoint p41 = new GPSPoint(4.1, 5.1);
            GPSPoint p42 = new GPSPoint(4.2, 5.2);
            GPSPoint p43 = new GPSPoint(4.3, 5.3);
            road4.AddPoint(p41);
            road4.AddPoint(p42);
            road4.AddPoint(p43);

            route.Add(road4);

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(route);

            Debug.WriteLine(json);
            string serializedRoute = "[{\"RoadName\":\"road1\",\"PointList\":[{\"Lat\":1.1,\"Lng\":2.1,\"IndexInList\":0,\"RoadName\":\"road1\"},{\"Lat\":1.2,\"Lng\":2.2,\"IndexInList\":1,\"RoadName\":\"road1\"},{\"Lat\":1.3,\"Lng\":2.3,\"IndexInList\":2,\"RoadName\":\"road1\"}],\"NextRoadNameList\":[\"road2\"]},{\"RoadName\":\"road2\",\"PointList\":[{\"Lat\":2.1,\"Lng\":3.1,\"IndexInList\":0,\"RoadName\":\"road2\"},{\"Lat\":2.2,\"Lng\":3.2,\"IndexInList\":1,\"RoadName\":\"road2\"},{\"Lat\":2.3,\"Lng\":3.3,\"IndexInList\":2,\"RoadName\":\"road2\"}],\"NextRoadNameList\":[\"road3\",\"road4\"]},{\"RoadName\":\"road3\",\"PointList\":[{\"Lat\":3.1,\"Lng\":4.1,\"IndexInList\":0,\"RoadName\":\"road3\"},{\"Lat\":3.2,\"Lng\":4.2,\"IndexInList\":1,\"RoadName\":\"road3\"},{\"Lat\":3.3,\"Lng\":4.3,\"IndexInList\":2,\"RoadName\":\"road3\"}],\"NextRoadNameList\":[]},{\"RoadName\":\"road4\",\"PointList\":[{\"Lat\":4.1,\"Lng\":5.1,\"IndexInList\":0,\"RoadName\":\"road4\"},{\"Lat\":4.2,\"Lng\":5.2,\"IndexInList\":1,\"RoadName\":\"road4\"},{\"Lat\":4.3,\"Lng\":5.3,\"IndexInList\":2,\"RoadName\":\"road4\"}],\"NextRoadNameList\":[]}]";

            List<RoadInfo> newRoute = (List<RoadInfo>)Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoadInfo>>(serializedRoute);
            Assert.IsTrue(newRoute[0].RoadName == road1.RoadName);
            Assert.IsTrue(newRoute[1].RoadName == road2.RoadName);
            Assert.IsTrue(newRoute[2].RoadName == road3.RoadName);
            Assert.IsTrue(newRoute[3].RoadName == road4.RoadName);
        }

        [TestMethod]
        public void TestMethod1()
        {
            string name = "road1";
            RoadInfo ri = new RoadInfo(name);
            Assert.IsTrue(ri.RoadName == name);

            Assert.IsTrue(ri.NextRoadNameList.Count == 0);
            Assert.IsTrue(ri.PointList.Count == 0);

            ri.AddPoint(new GPSPoint(1.1, 2.1));
            ri.AddPoint(new GPSPoint(1.2, 2.2));

            Assert.IsTrue(ri.PointList.Count == 2);

            ri.AddNextRoadName("road2");
            ri.AddNextRoadName("road3");

            Assert.IsTrue(ri.NextRoadNameList.Count == 2);
        }

        [TestMethod]
        public void TestPlayRoad()
        {
            //初始化一条路线,是由多条路组成的
            List<RoadInfo> roads = new List<RoadInfo>();

            //初始化一条路,并为其添加一些关键点
            RoadInfo road1 = new RoadInfo("road1");
            GPSPoint p11 = new GPSPoint(1.1, 2.1);
            GPSPoint p12 = new GPSPoint(1.2, 2.2);
            GPSPoint p13 = new GPSPoint(1.3, 2.3);
            road1.AddPoint(p11);
            road1.AddPoint(p12);
            road1.AddPoint(p13);

            road1.AddNextRoadName("road2");
            roads.Add(road1);

            RoadInfo road2 = new RoadInfo("road2");
            GPSPoint p21 = new GPSPoint(2.1, 3.1);
            GPSPoint p22 = new GPSPoint(2.2, 3.2);
            GPSPoint p23 = new GPSPoint(2.3, 3.3);
            road2.AddPoint(p21);
            road2.AddPoint(p22);
            road2.AddPoint(p23);

            //为该条路添加可以选择的路
            road2.AddNextRoadName("road3");
            road2.AddNextRoadName("road4");

            roads.Add(road2);

            RoadInfo road3 = new RoadInfo("road3");
            GPSPoint p31 = new GPSPoint(3.1, 4.1);
            GPSPoint p32 = new GPSPoint(3.2, 4.2);
            GPSPoint p33 = new GPSPoint(3.3, 4.3);


            road3.AddPoint(p31);
            road3.AddPoint(p32);
            road3.AddPoint(p33);

            roads.Add(road3);


            RoadInfo road4 = new RoadInfo("road4");
            GPSPoint p41 = new GPSPoint(4.1, 5.1);
            GPSPoint p42 = new GPSPoint(4.2, 5.2);
            GPSPoint p43 = new GPSPoint(4.3, 5.3);
            road4.AddPoint(p41);
            road4.AddPoint(p42);
            road4.AddPoint(p43);

            roads.Add(road4);

            //添加运行到关键点的事件响应
            Action<GPSPoint> ringer = _point =>
            {
                Debug.WriteLine(_point.FormatPointString());
            };

            //添加当该条路线有继续运行的路时的事件响应
            Action<List<string>> RoadSelectRinger = _list =>
                {
                    //打印出可以选择的道路
                    foreach (string s in _list)
                    {
                        Debug.WriteLine("next road => " + s);
                    }
                };

            RoadPlayer player = RoadPlayer.InitializeRoadPlayer(roads, ringer, RoadSelectRinger);
            GPSPoint pointTemp = player.Play();

            Assert.IsTrue(pointTemp.RoadName == road1.RoadName && pointTemp.IndexInList == 0 && pointTemp.Lat == p11.Lat && pointTemp.Lng == p11.Lng);

            pointTemp = player.Play(pointTemp);
            Assert.IsTrue(pointTemp.RoadName == road1.RoadName && pointTemp.IndexInList == 1 && pointTemp.Lat == p12.Lat && pointTemp.Lng == p12.Lng);

            pointTemp = player.Play(pointTemp);
            Assert.IsTrue(pointTemp.RoadName == road1.RoadName && pointTemp.IndexInList == 2 && pointTemp.Lat == p13.Lat && pointTemp.Lng == p13.Lng);

            pointTemp = player.Play(pointTemp);
            Assert.IsTrue(pointTemp.RoadName == road2.RoadName && pointTemp.IndexInList == 0 && pointTemp.Lat == p21.Lat && pointTemp.Lng == p21.Lng);
            pointTemp = player.Play(pointTemp);
            Assert.IsTrue(pointTemp.RoadName == road2.RoadName && pointTemp.IndexInList == 1 && pointTemp.Lat == p22.Lat && pointTemp.Lng == p22.Lng);
            pointTemp = player.Play(pointTemp);
            Assert.IsTrue(pointTemp.RoadName == road2.RoadName && pointTemp.IndexInList == 2 && pointTemp.Lat == p23.Lat && pointTemp.Lng == p23.Lng);

            player.SetNextRoadName("road4");

            pointTemp = player.Play(pointTemp);
            Assert.IsTrue(pointTemp.RoadName == road4.RoadName && pointTemp.IndexInList == 0 && pointTemp.Lat == p41.Lat && pointTemp.Lng == p41.Lng);

            pointTemp = player.Play(pointTemp);
            Assert.IsTrue(pointTemp.RoadName == road4.RoadName && pointTemp.IndexInList == 1 && pointTemp.Lat == p42.Lat && pointTemp.Lng == p42.Lng);

        }
    }
}
