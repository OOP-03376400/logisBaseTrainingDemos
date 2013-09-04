using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactorySystem
{
    public class Product
    {
        private string strcode;//产品编号
        public string Pro_code
        {
            get { return strcode; }
            set { strcode = value; }
        }
        private string strname;//产品名称
        public string Pro_Name
        {
            get { return strname; }
            set { strname = value; }
        }
        private string strLeibie;//产品类别
        public string Pro_Leibie
        {
            get { return strLeibie; }
            set { strLeibie = value; }
        }
        private string strGui;//产品规格
        public string Pro_Gui
        {
            get { return strGui; }
            set { strGui = value; }
        }
        private string strPici;//产品批次
        public string Pro_Pici
        {
            get { return strPici; }
            set { strPici = value; }
        }
        private string strstate;//生产状态
        public string Pro_state
        {
            get { return strstate; }
            set { strstate = value; }
        }
        private string strChej;//生产车间
        public string Pro_Chej
        {
            get { return strChej; }
            set { strChej = value; }
        }
        private string strPer;//生产负责人
        public string Pro_Person
        {
            get { return strPer; }
            set { strPer = value; }
        }
      
        private string strcontact;//联系方式
        public string Contact
        {
            get { return strcontact; }
            set { strcontact = value; }
        }
        private string strremark;//备注
        public string Remark
        {
            get { return strremark; }
            set { strremark = value; }
        }
        private string strfalg;//标记
        public string falg
        {
            get { return strfalg; }
            set { strfalg = value; }
        }
        private string strfitime;//生产完成时间
        public string finishTime
        {
            get { return strfitime; }
            set { strfitime = value; }
        }
        private string strtempre;//生产温度
        public string Pro_Tempre
        {
            get { return strtempre; }
            set { strtempre = value; }
        }
        private string strwet;//生产湿度
        public string Pro_Wet
        {
            get { return strwet; }
            set { strwet = value; }
        }
        public Product()
        {

        }
    }
}
