using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace INFO4430_Fall2020_MVC.Models {
    public class Course_old {
        private int _ID;
        private String _Name;
        private int _IndexNumber;
        private int _InstructorID;
        private List<Student> _Students;

        public Course_old() {

        }

        [Key]
        public int ID {
            get { return _ID; }
            set { _ID = value; }
        }

        public int CourseID {
            get { return _ID; }
            set { _ID = value; }
        }

        [StringLength(50)]
        public String Name {
            get { return _Name; }
            set { _Name = value; }
        }

        public int IndexNumber {
            get { return _IndexNumber; }
            set { _IndexNumber = value; }
        }

        [Display(Name = "Professor ID")]
        public int InstructorID {
            get { return _InstructorID; }
            set { _InstructorID = value; }
        }

        public List<Student> Students {
            get {
                if (_Students == null) 
                    _Students = new List<Student>();
                return _Students;
            }
        }

    }
}
