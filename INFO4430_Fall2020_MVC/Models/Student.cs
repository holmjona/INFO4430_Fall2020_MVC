//Created By: holmjona (using Code generator)
//Created On: 11/11/2020 10:18:07 PM
using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;
namespace INFO4430_Fall2020_MVC.Models
{
        /// <summary>
        /// TODO: Comment this
        /// </summary>
        /// <remarks></remarks>

    public class Student: DatabaseRecord
{
#region Constructors
        public Student()
        {
        }
        internal Student(Microsoft.Data.SqlClient.SqlDataReader dr)
        {
            Fill(dr);
        }

#endregion

#region Database String
        internal const string db_ID= "StudentID";
        internal const string db_FirstName= "FirstName";
        internal const string db_LastName= "LastName";
        internal const string db_Age= "Age";
        internal const string db_NickName= "NickName";
        internal const string db_FavoriteColor= "FavoriteColor";

#endregion

#region Private Variables
        private string _FirstName;
        private string _LastName;
        private int _Age;
        private string _NickName;
        private string _FavoriteColor;

#endregion

#region Public Properties
        /// <summary>
        /// Gets or sets the FirstName for this INFO4430_Fall2020_MVC.Models.Student object.
        /// </summary>
        /// <remarks></remarks>
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
        /// Gets or sets the LastName for this INFO4430_Fall2020_MVC.Models.Student object.
        /// </summary>
        /// <remarks></remarks>
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
        /// Gets or sets the Age for this INFO4430_Fall2020_MVC.Models.Student object.
        /// </summary>
        /// <remarks></remarks>
        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }

        /// <summary>
        /// Gets or sets the NickName for this INFO4430_Fall2020_MVC.Models.Student object.
        /// </summary>
        /// <remarks></remarks>
        public string NickName
        {
            get
            {
                return _NickName;
            }
            set
            {
                _NickName = value.Trim();
            }
        }

        /// <summary>
        /// Gets or sets the FavoriteColor for this INFO4430_Fall2020_MVC.Models.Student object.
        /// </summary>
        /// <remarks></remarks>
        public string FavoriteColor
        {
            get
            {
                return _FavoriteColor;
            }
            set
            {
                _FavoriteColor = value.Trim();
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
        /// Calls DAL function to add Student to the database.
        /// </summary>
        /// <remarks></remarks>
        protected override int dbAdd()
        {
            _ID = DAL.AddStudent(this);
            return ID;
        }

        /// <summary>
        /// Calls DAL function to update Student to the database.
        /// </summary>
        /// <remarks></remarks>
        protected override int dbUpdate()
        {
            return DAL.UpdateStudent(this);
        }

        /// <summary>
        /// Calls DAL function to remove Student from the database.
        /// </summary>
        /// <remarks></remarks>
        public override int dbDelete()
        {
            return DAL.RemoveStudent(this);
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
            _Age = (int)dr[db_Age];
            _NickName = (string)dr[db_NickName];
            _FavoriteColor = (string)dr[db_FavoriteColor];
        }

#endregion

        public override string ToString()
        {
            return this.GetType().ToString();
        }

    }
}
