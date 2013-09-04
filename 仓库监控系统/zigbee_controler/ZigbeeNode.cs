using System;
using System.Collections.Generic;
using System.Text;

namespace zigbee_controler
{
    public class ZigbeeNode
    {


        public string node_id = string.Empty;

        public string location = string.Empty;

        public string max_temp = string.Empty;
        public string min_temp = string.Empty;

        public string max_humi = string.Empty;
        public string min_humi = string.Empty;

        public string state = string.Empty;

        public ZigbeeNode()
        {
        }
        public ZigbeeNode(string _node_id, string _location, string _max_temp, string _min_temp, string _max_humi, string _min_humi)
        {
            this.node_id = _node_id;
            this.location = _location;
            this.max_temp = _max_temp;
            this.min_temp = _min_temp;
            this.max_humi = _max_humi;
            this.min_humi = _min_humi;
        }



    }
}
