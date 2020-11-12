using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace INFO4430_Fall2020_MVC.Models {
    public class Student_old {
        private int _ID;
        private String _FirstName = "";
        private String _LastName = "";
        private String _NickName = "";
        private int _Age = 0;
        private String _FavoriteColor;

        public Student_old() {
            initializeValues("Joe", "Nobody", 0, "Black", -1);
        }
        public Student_old(String newFirstName, String newLastName, int newAge,
            string newColor, int newID) {
            initializeValues(newFirstName, newLastName, newAge, newColor, newID);
        }

        private void initializeValues(String newFirstName, String newLastName,
                    int newAge, string newColor, int newID) {
            _Age = newAge; FirstName = newFirstName;
            LastName = newLastName; _FavoriteColor = newColor; _ID = newID;
        }

        [Key]
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }

        [Display(Name = "First Name")]
        [StringLength(50)]
        public String FirstName {
            get { return _FirstName; }
            set { _FirstName = value.Trim(); }
        }

        [Display(Name = "Last Name")]
        [StringLength(60)]
        public String LastName {
            get { return _LastName; }
            set { _LastName = value.Trim(); }
        }

        [Display(Name = "Nick Name")]
        [StringLength(50)]
        public String NickName {
            get { return _NickName; }
            set { _NickName = value.Trim(); }
        }

        [Range(1, 500)]
        public int Age {
            get { return _Age; }
            set { _Age = value; }
        }

        [Display(Name = "Favorite Color")]
        [StringLength(40)]
        public String FavoriteColor {
            get { return _FavoriteColor; }
            set { _FavoriteColor = value.Trim(); }
        }


        public String FullName {
            get {
                return FirstName + " " + LastName;
            }
        }

        public String Color {
            get { return _FavoriteColor; }
            set { _FavoriteColor = value; }
        }

        public override string ToString() {
            return String.Format("Name: {0} Age: {1}" +
                " Color: {2}", FullName, Age, Color);
        }

    }
}

