using System;
using System.Collections.Generic;
using System.Text;
using nsConfigDB;

namespace FactorySystem
{
    public class RestUrl
    {
        //  public static string RestAddress = "http://192.168.0.82:9002/index.php/IntelligentMarket/";
        public static string IP = ConfigDB.getConfig("IP").ToString();
        //  public static string RestAddress = "http://192.168.0.82:9002/index.php/IntelligentMarket/";
        public static string BaseRestAddress = "http://" + staticClass.restServerIP + ":" + staticClass.restServerPort + "/index.php/";
        public static string RestAddress = BaseRestAddress + "IntelligentProduct/";

        //修改中的url
        //生产部分
        public static string NewgetProducingdata = RestAddress + "MenuNewProducing/FindProducingdata";//获取待生产产品信息
        public static string NewgetProducedData = RestAddress + "MenuNewProducing/FindProduceddata";//获取产成品信息

        public static string test_isexist = RestAddress + "boxproduce/isexist";//检验编码是否存在 
        public static string Find_code_Info = RestAddress + "boxproduce/Find_code_Info";//查询检测到的编码信息 
        public static string add_New_Code = RestAddress + "boxproduce/add_New_Code";//添加信息标签
        public static string Put_toProduce = RestAddress + "boxproduce/Put_toProduce";//推送至毛坯库（即待生产）
        public static string FindProducingInfo = RestAddress + "boxproduce/FindProducingInfo";//查看待生产产品信息
        public static string updateProducedData = RestAddress + "boxproduce/updateProducedData";//更新生产完成产品信息
        public static string FindProduceddata = RestAddress + "boxproduce/FindProduceddata";//查看产成品信息
        public static string indexdata = RestAddress + "boxproduce/indexdata";//根据条件检索产品信息

        public static string getZigbeeInfo = BaseRestAddress + "Zigbee/zigbee/getZigbeeInfo";







        //public static string getAllFOrders = RestAddress + "FOrders/getAllFOrders";
        //public static string updateFOrders = RestAddress + "FOrders/updateFOrders";
        //public static string deleteFOrders = RestAddress + "FOrders/deleteFOrders";
        //public static string addFOrders = RestAddress + "FOrders/addFOrders";
        //public static string getFOrders = RestAddress + "FOrders/getFOrders";

        //public static string addFProduct = RestAddress + "FProduct/addFProduct";



        public static string addCommandInfo = RestAddress + "LED/CommandInfo/addCommandInfo";

    }
}
