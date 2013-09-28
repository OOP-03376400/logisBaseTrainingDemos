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
            List<RoadInfo> roads = new List<RoadInfo>();

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


            Action<GPSPoint> ringer = _point =>
            {
                Debug.WriteLine(_point.FormatPointString());
            };
            Action<List<string>> RoadSelectRinger = _list =>
                {
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
