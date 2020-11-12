using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INFO4430_Fall2020_MVC.Models {
    public abstract class DatabaseRecord
    {
        #region Private Variable
        protected int _ID;
        #endregion		
		
        #region Public Properties
        /// <summary>
        /// Gets or sets value for ID
        /// </summary>
        public int ID {
            get {
                return _ID;
            }
            set {
                _ID = value;
            }
        }		
		#endregion

		#region Database Methods
		protected abstract int dbAdd();
		protected abstract int dbUpdate();
		public abstract int dbSave();
		public abstract int dbDelete();

        #endregion
    }
}