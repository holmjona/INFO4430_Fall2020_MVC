//Created By: holmjona (using Code generator)
//Created On: 11/11/2020 10:18:07 PM
using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace INFO4430_Fall2020_MVC.Models
{
        /// <summary>
        /// TODO: Comment this
        /// </summary>
        /// <remarks></remarks>

    public class Instructor :DatabaseRecord
{
#region Constructors
        public Instructor()
        {
        }
        internal Instructor(Microsoft.Data.SqlClient.SqlDataReader dr)
        {
            Fill(dr);
        }

#endregion

#region Database String
        internal const string db_ID= "InstructorID";
        internal const string db_FirstName= "FirstName";
        internal const string db_LastName= "LastName";
        internal const string db_Office= "Office";

#endregion

#region Private Variables
        private string _FirstName;
        private string _LastName;
        private int _Office;

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the FirstName for this INFO4430_Fall2020_MVC.Models.Instructor object.
        /// </summary>
        /// <remarks></remarks>
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value.Trim();
            }
        }

        /// <summary>
        /// Gets or sets the LastName for this INFO4430_Fall2020_MVC.Models.Instructor object.
        /// </summary>
        /// <remarks></remarks>
        [Display(Name = "Last Name")]
        [StringLength(60)]
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value.Trim();
            }
        }

        /// <summary>
        /// Gets or sets the Office for this INFO4430_Fall2020_MVC.Models.Instructor object.
        /// </summary>
        /// <remarks></remarks>
        [Display(Name = "Office Number")]
        [Range(1, 999)]
        public int Office
        {
            get
            {
                return _Office;
            }
            set
            {
                _Office = value;
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
        /// Calls DAL function to add Instructor to the database.
        /// </summary>
        /// <remarks></remarks>
        protected override int dbAdd()
        {
            _ID = DAL.AddInstructor(this);
            return ID;
        }

        /// <summary>
        /// Calls DAL function to update Instructor to the database.
        /// </summary>
        /// <remarks></remarks>
        protected override int dbUpdate()
        {
            return DAL.UpdateInstructor(this);
        }

        /// <summary>
        /// Calls DAL function to remove Instructor from the database.
        /// </summary>
        /// <remarks></remarks>
        public override int dbDelete()
        {
            return DAL.RemoveInstructor(this);
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
            _FirstName = (string)dr[db_FirstName];
            _LastName = (string)dr[db_LastName];
            _Office = (int)dr[db_Office];
        }

#endregion

        public override string ToString()
        {
            return this.GetType().ToString();
        }

    }
}
