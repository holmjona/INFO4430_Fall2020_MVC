using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFO4430_Fall2020_MVC.Models {
    public class User {

        private int _ID;
        private string _FirstName;
        private string _LastName;


        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }

        public string FirstName {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName {
            get { return _LastName; }
            set { _LastName = value; }
        }


    }
}
