using System;
using System.Collections.Generic;
using System.Text;
using zigbee_controler;

namespace RestAPI
{
    public delegate void deleControlInvoke(object o);

    public class RestUrl
    {
        public static string RestAddress = "http://" + staticClass.restServerIP + ":" + staticClass.restServerPort + "/index.php/";
        //public static string RestAddress = "http://192.168.0.82:9002/index.php/";

        public static string getCommand = RestAddress + "RFIDReader/Communication/getCommand";
        public static string addCommand = RestAddress + "RFIDReader/Communication/addCommand";

        //  public static string addwareHouseInfo = RestAddress + "LED/wareHouse/addwareHouse";
        //public static string addwareHouseInfo = RestAddress + "LED/wareHouse/addwareHouse";
        //public static string updatewareHouseInfo = RestAddress + "LED/wareHouse/updatewareHouseInfo";
        //public static string getwareHouse = RestAddress + "LED/wareHouse/getwareHouse";


        public static string addZigbeeInfo = RestAddress + "Zigbee/zigbee/addZigbeeInfo";

        public static string getAllZigbeeNodes = RestAddress + "Zigbee/zigbee/getAllZigbeeNodes";
        public static string addZigbeeNode = RestAddress + "Zigbee/zigbee/addZigbeeNode";
        public static string getZigbeeNode = RestAddress + "Zigbee/zigbee/getZigbeeNode";
        public static string deleteZigbeeNode = RestAddress + "Zigbee/zigbee/deleteZigbeeNode";
    }
}
