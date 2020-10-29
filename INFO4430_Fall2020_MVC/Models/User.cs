using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace INFO4430_Fall2020_MVC.Models {
    public class User {

        private int _ID;
        private string _FirstName;
        private string _LastName;
        private string _Password;
        private bool _IsAwesome;


        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }

        [Display(Name = "First Name")]
        [Required(ErrorMessage ="Please enter a {0}.")]
        public string FirstName {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        [Display(Name = "Surname")]
        public string LastName {
            get { return _LastName; }
            set { _LastName = value; }
        }


        [DataType(DataType.Password)]
        public string Password {
            get { return _Password; }
            set { _Password = value; }
        }

        [UIHint("YesNo")]
        public bool IsAwesome {
            get { return _IsAwesome; }
            set { _IsAwesome = value; }
        }


        //public void SetCount(int a) {

        //}

        //public int GetCount() {
        //    return 1;
        //}


    }
}
