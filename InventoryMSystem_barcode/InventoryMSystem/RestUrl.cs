using System;
using System.Collections.Generic;
using System.Text;
using InventoryMSystem;

namespace Inventory
{
    public class RestUrl
    {
        public static string RestAddress = "http://" + staticClass.restServerIP + ":" + staticClass.restServerPort + "/index.php/";
        //public static string RestAddress = "http://192.168.0.82:9002/index.php/";
        public static string addProduct = RestAddress + "Inventory_barcode/Inventory/addProduct";
        public static string updateProduct = RestAddress + "Inventory_barcode/Inventory/updateProduct";
        public static string deleteProduct = RestAddress + "Inventory_barcode/Inventory/deleteProduct";
        public static string allProducts = RestAddress + "Inventory_barcode/Inventory/getAllProducts";
        public static string getProduct = RestAddress + "Inventory_barcode/Inventory/getProduct";
        public static string addProductToStorage = RestAddress + "Inventory_barcode/Inventory/addProductToStorage";
        public static string getPreProListToStorage = RestAddress + "Inventory_barcode/Inventory/getPreProListToStorage";
        public static string deleteProductFromStorage = RestAddress + "Inventory_barcode/Inventory/deleteProductFromStorage";
        public static string getProductList4deleteProductFromStorage = RestAddress + "Inventory_barcode/Inventory/getProductList4deleteProductFromStorage";
        public static string getProductInfoForInventoryList = RestAddress + "Inventory_barcode/Inventory/getProductInfoForInventoryList";

        public static string addScanedTag = RestAddress + "RFIDReader/Reader/addScanTag";
        public static string addScanedTags = RestAddress + "RFIDReader/Reader/addScanTags";
        public static string getScanedTags = RestAddress + "RFIDReader/Reader/getScanTags";


        public static string getAllOrders = RestAddress + "Inventory_barcode/Order/getAllOrders";
        public static string addOrder = RestAddress + "Inventory_barcode/Order/addOrder";
        public static string deleteOrder = RestAddress + "Inventory_barcode/Order/deleteOrder";
        public static string deleteOrders = RestAddress + "Inventory_barcode/Order/deleteOrders";

        public static string allProductName = RestAddress + "Inventory_barcode/ProductName/getAllProductName";


        public static string sendUDP = RestAddress + "Inventory_barcode/UdpInvoke/sendUDPCommand/cmd/1";

    }
}
