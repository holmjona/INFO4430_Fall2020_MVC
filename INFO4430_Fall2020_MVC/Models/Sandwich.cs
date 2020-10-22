using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFO4430_Fall2020_MVC.Models {
    public class Sandwich {
        public enum Types {
            Burger,
            Chicken,
            Meatless
        }

        private Types _Type;

        public Types Type {
            get { return _Type; }
            set { _Type = value; }
        }

        private int _PattyCount;

        public int PattyCount {
            get { return _PattyCount; }
            set { _PattyCount = value; }
        }


    }
}
