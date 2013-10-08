using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace transportSimulation
{
    public class RoadPlayer
    {
        public Action<GPSPoint> pointRinger = null;
        public Action<List<string>> RoadSelectRinger = null;

        List<RoadInfo> RoadList = new List<RoadInfo>();
        string NextRoadName = string.Empty;

        public static RoadPlayer InitializeRoadPlayer(List<RoadInfo> list, Action<GPSPoint> _ringer, Action<List<string>> _roadSelectRinger = null)
        {
            if (list == null || list.Count <= 0) return null;

            if (list.Any(_ri => { return _ri.PointList.Count > 0 && _ri.NextRoadNameList.Count > 0; }))
            {
                return new RoadPlayer(list, _ringer, _roadSelectRinger);
            }
            else
                return null;
        }
        RoadPlayer(List<RoadInfo> list, Action<GPSPoint> _ringer = null, Action<List<string>> _roadSelectRinger = null)
        {
            this.RoadList = list;
            this.pointRinger = _ringer;
            this.RoadSelectRinger = _roadSelectRinger;
        }
        public void SetNextRoadName(string _name)
        {
            this.NextRoadName = _name;
        }

        public GPSPoint Play(GPSPoint _GpsPoint = null, string _roadName = "")
        {
            RoadInfo riTemp = null;

            if (_GpsPoint == null)
            {
                if (_roadName == "")
                {
                    riTemp = this.RoadList[0];
                }
                else
                {
                    riTemp = RoadList.First(_ri => { return _ri.RoadName == _roadName; });
                }
                if (riTemp == null) return null;

                if (RoadSelectRinger != null)
                {
                    RoadSelectRinger(riTemp.NextRoadNameList);
                }
                return riTemp.PointList[0];
            }

            RoadInfo ri = RoadList.First(_ri => { return _ri.RoadName == _GpsPoint.RoadName; });
            if (ri != null)
            {
                if (_GpsPoint.IndexInList < ri.PointList.Count - 1)
                {
                    var point = ri.PointList.First(_point => _point.IndexInList == (_GpsPoint.IndexInList + 1));

                    if (this.pointRinger != null)
                    {
                        this.pointRinger(point);
                    }
                    return point;
                }
                else
                {
                    if (ri.NextRoadNameList.Contains(this.NextRoadName))
                    {
                        return Play(null, this.NextRoadName);

                    }
                    else
                    {
                        //往下没路了，提醒结束
                        if (ri.NextRoadNameList.Count <= 0)
                        {
                            if (pointRinger != null)
                            {
                                pointRinger(null);
                            }
                            return null;
                        }
                        else
                            //第一条路
                            return Play(null, ri.NextRoadNameList[0]);
                    }
                }
            }

            return null;
        }
    }

    public class RoadInfo
    {
        public string RoadName = string.Empty;
        public List<GPSPoint> PointList = new List<GPSPoint>();
        public List<string> NextRoadNameList = new List<string>();

        public RoadInfo() { }
        public RoadInfo(string _name)
        {
            this.RoadName = _name;
        }

        public void AddPoint(GPSPoint _point)
        {
            _point.IndexInList = this.PointList.Count;
            _point.RoadName = this.RoadName;
            PointList.Add(_point);
        }

        public void AddNextRoadName(string _name)
        {
            this.NextRoadNameList.Add(_name);
        }
    }

    public class GPSPoint
    {
        public double Lat = 0.0;
        public double Lng = 0.0;

        public int IndexInList = 0;
        public string RoadName = string.Empty;
        public GPSPoint(double _lat, double _lng)
        {
            this.Lat = _lat;
            this.Lng = _lng;
        }

        public string FormatPointString()
        {
            return string.Format("RoadName => {3}  Index : {0}  Lat: {1}, Lng: {2}", this.IndexInList.ToString(), this.Lat.ToString(), this.Lng.ToString(), this.RoadName);
        }
    }
}
