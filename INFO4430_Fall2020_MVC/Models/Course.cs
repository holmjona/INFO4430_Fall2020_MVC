//Created By: holmjona (using Code generator)
//Created On: 11/11/2020 10:18:07 PM
using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INFO4430_Fall2020_MVC.Models {
        /// <summary>
        /// TODO: Comment this
        /// </summary>
        /// <remarks></remarks>

    public class Course: DatabaseRecord
{
#region Constructors
        public Course()
        {
        }
        internal Course(Microsoft.Data.SqlClient.SqlDataReader dr)
        {
            Fill(dr);
        }

#endregion

#region Database String
        internal const string db_ID= "CourseID";
        internal const string db_Name= "Name";
        internal const string db_IndexNumber= "IndexNumber";
        internal const string db_Professor= "ProfessorID";

#endregion

#region Private Variables
        private string _Name;
        private int _IndexNumber;
        private int _Professor;

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the Name for this INFO4430_Fall2020_MVC.Models.Course object.
        /// </summary>
        /// <remarks></remarks>
        [StringLength(50)]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value.Trim();
            }
        }

        /// <summary>
        /// Gets or sets the IndexNumber for this INFO4430_Fall2020_MVC.Models.Course object.
        /// </summary>
        /// <remarks></remarks>
        public int IndexNumber
        {
            get
            {
                return _IndexNumber;
            }
            set
            {
                _IndexNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the Professor for this INFO4430_Fall2020_MVC.Models.Course object.
        /// </summary>
        /// <remarks></remarks>
        [Display(Name = "Professor ID")]
        public int InstructorID
        {
            get
            {
                return _Professor;
            }
            set
            {
                _Professor = value;
            }
        }


        #endregion

        #region Public Functions
        /// <summary>
        /// Based on ID creates or updates record in database.
        /// An ID of -1 assumed to not be in the database and will be added.
        /// </summary>
        /// <returns> 
        ///		<= 0 on fail
        ///		> 0 on success
        /// </returns>
        public override int dbSave() {
            if (_ID == -1) {
                return dbAdd();
            } else {
                return dbUpdate();
            }
        }
        /// <summary>
        /// Calls DAL function to add Course to the database.
        /// </summary>
        /// <remarks></remarks>
        protected override int dbAdd()
        {
            _ID = DAL.AddCourse(this);
            return ID;
        }

        /// <summary>
        /// Calls DAL function to update Course to the database.
        /// </summary>
        /// <remarks></remarks>
        protected override int dbUpdate()
        {
            return DAL.UpdateCourse(this);
        }

        /// <summary>
        /// Calls DAL function to remove Course from the database.
        /// </summary>
        /// <remarks></remarks>
        public override int dbDelete()
        {
            return DAL.RemoveCourse(this);
        }

#endregion

#region Public Subs
        /// <summary>
        /// Fills object from a SqlClient Data Reader
        /// </summary>
        /// <remarks></remarks>
        public void Fill(Microsoft.Data.SqlClient.SqlDataReader dr)
        {
            _ID = (int)dr[db_ID];
            _Name = (string)dr[db_Name];
            _IndexNumber = (int)dr[db_IndexNumber];
            _Professor = (int)dr[db_Professor];
        }

#endregion

        public override string ToString()
        {
            return this.GetType().ToString();
        }

    }
}
