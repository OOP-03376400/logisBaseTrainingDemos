using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactorySystem
{
     public class indexinfo
    {
        private int _num;
        public int num
        {
            get { return _num; }
            set { _num = value;}
        }
        private string _condition;
        public string conditon
        {
            get { return _condition;}
            set { _condition = value; }
        }
        private string _state;
        public string state
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
