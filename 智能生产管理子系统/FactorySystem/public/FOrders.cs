using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactorySystem
{
    class FOrders
    {
         public string orderID=string .Empty ;

         public string Theorders=string .Empty ; 
        public string prductName=string .Empty ;
         public string Number=string .Empty ;
         public string productCategory=string .Empty ;
         public string time=string .Empty ;
         public string orderState=string .Empty ;
           public string address=string .Empty ;
           public string beiZhu=string .Empty ;
           public string state = string.Empty;
           public FOrders() { }
           public FOrders(string _orderID, string _Theorders, string _prductName, string _Number, string _productCategory, string _time, string _orderState, string _address, string _beiZhu,string _state) 
           {
               orderID=_orderID;
               Theorders = _Theorders;
                Number=_Number;
              prductName =_prductName;
             productCategory  =_productCategory;
               time=_time;
               orderState=_orderState;
              address =_beiZhu;
              beiZhu = _beiZhu;
              state =_state;
           
           }

    }
}
