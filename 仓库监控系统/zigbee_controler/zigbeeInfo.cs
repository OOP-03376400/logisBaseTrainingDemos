using System;
using System.Collections.Generic;
using System.Text;

namespace zigbee_controler
{
    public class zigbeeInfo
    {
        public string node_id = string.Empty;
        public string startTime = string.Empty;
        public string temp = string.Empty;
        public string humi = string.Empty;
        public string light = string.Empty;
        public string state = string.Empty;

        public zigbeeInfo() { }
        public zigbeeInfo(string _node_id, string _startTime, string _temp, string _humi, string _light, string _state)
        {
            this.node_id = _node_id;
            this.startTime = _startTime;
            this.temp = _temp;
            this.humi = _humi;
            this.light = _light;
            this.state = _state;
        }
    }
}
