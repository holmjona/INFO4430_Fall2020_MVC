using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace INFO4430_Fall2020_MVC.Models {
    public class Instructor_old {

        private int _ID;
        private String _FirstName;
        private String _LastName;
        private int _Office;

        [Key]
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }

        [Display(Name ="First Name")]
        [StringLength(50)]
        public String FirstName {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        [Display(Name = "Last Name")]
        [StringLength(60)]
        public String LastName {
            get { return _LastName; }
            set { _LastName = value; }
        }

        /// <summary>
        /// Office Number for the Instructor.
        /// </summary>
        [Display(Name ="Office Number")]
        [Range(1,999)]
        public int Office {
            get { return _Office; }
            set { _Office = value; }
        }


    }
}
