using System;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace INFO4430_Fall2020_MVC.Models
{
    public class DAL 
    {
        private static string ReadOnlyConnectionString = "Server=localhost; Database=4430Demo;Trusted_Connection=True;";
        private static string EditOnlyConnectionString = "Server=localhost; Database=4430Demo;Trusted_Connection=True;";
        private DAL()
        {
        }
        internal enum dbAction 
        {
            Read,
            Edit
        }

        private static List<User> _Users = null;

        public static List<User> GetUsers() {
            if (_Users == null) {
                PopulateUsers();
            }
            return _Users;
        }

        private static void PopulateUsers() {
            _Users = new List<User>();
            _Users.Add(new Models.User() { ID = 1, FirstName = "Ry", LastName = "O", IsAwesome = true });
            _Users.Add(new Models.User() { ID = 2, FirstName = "Brandon", LastName = "W", IsAwesome = true });
            _Users.Add(new Models.User() { ID = 3, FirstName = "Jon", LastName = "H" });
        }

        public static User GetUser(int id) {
            User userFound = _Users.FirstOrDefault(u => u.ID == id);
            return userFound;
        }

        #region Database Connections
        internal static void ConnectToDatabase(SqlCommand comm, dbAction action = dbAction.Read)
        {
            try
            {
                if (action == dbAction.Edit)
                    comm.Connection = new SqlConnection(EditOnlyConnectionString);
                else
                    comm.Connection = new SqlConnection(ReadOnlyConnectionString);
                
                comm.CommandType = CommandType.StoredProcedure;
            }catch(Exception ex){}
        }
        public static SqlDataReader GetDataReader(SqlCommand comm)
        {
            try
            {
                ConnectToDatabase(comm);
                comm.Connection.Open();
                return comm.ExecuteReader();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }
        
        
        internal static int AddObject(SqlCommand comm, string parameterName)
        {
            int retInt = 0;
            try
            {
                comm.Connection = new SqlConnection(EditOnlyConnectionString);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Connection.Open();
                SqlParameter retParameter;
                retParameter = comm.Parameters.Add(parameterName, SqlDbType.Int);
                retParameter.Direction = ParameterDirection.Output;
                comm.ExecuteNonQuery();
                retInt = (int)retParameter.Value;
                comm.Connection.Close();
            }
            catch (Exception ex)
            {
                if (comm.Connection != null)
                    comm.Connection.Close();
                
                retInt = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            return retInt;
        }
        
        
        /// <summary>
        /// Sets Connection and Executes given comm on the database
        /// </summary>
        /// <param name="comm">SQLCommand to execute</param>
        /// <returns>number of rows affected; -1 on failure, positive value on success.</returns>
        /// <remarks>Must make sure to populate the command with sqltext and any parameters before passing to this function.
        ///       Edit Connection is set here.</remarks>
        internal static int UpdateObject(SqlCommand comm)
        {
            int retInt = 0;
            try
            {
                comm.Connection = new SqlConnection(EditOnlyConnectionString);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Connection.Open();
                retInt = comm.ExecuteNonQuery();
                comm.Connection.Close();
            }
            catch(Exception ex)
            {
                if(comm.Connection != null)
                    comm.Connection.Close();
                
                retInt = -1;
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            return retInt;
        }
#endregion


#region Instructor
        /// <summary>
        /// Gets the INFO4430_Fall2020_MVC.Models.Instructor correposponding with the given ID
        /// </summary>
        /// <remarks></remarks>

        public static Instructor GetInstructor(String idstring, Boolean retNewObject)
        {
            Instructor retObject = null;
            int ID;
            if (int.TryParse(idstring, out ID))
            {
                if (ID == -1 && retNewObject)
                {
                    retObject = new Instructor();
                    retObject.ID = -1;
                }
                else if (ID >= 0)
                {
                    retObject = GetInstructor(ID);
                }
            }
            return retObject;
        }


        /// <summary>
        /// Gets the INFO4430_Fall2020_MVC.Models.Instructorcorresponding with the given ID
        /// </summary>
        /// <remarks></remarks>

        public static Instructor GetInstructor(int id)
        {
            SqlCommand comm = new SqlCommand("sprocInstructorGet");
            Instructor retObj = null;
            try
            {
                comm.Parameters.AddWithValue("@" + Instructor.db_ID, id);
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read())
                {
                    retObj = new Instructor(dr);
                }
                comm.Connection.Close();
            }
            catch (Exception ex)
            {
                comm.Connection.Close();
            }
            return retObj;
        }


        /// <summary>
        /// Gets a list of all INFO4430_Fall2020_MVC.Models.Instructor objects from the database.
        /// </summary>
        /// <remarks></remarks>
        public static List<Instructor> GetInstructors()
        {
            SqlCommand comm = new SqlCommand("sprocInstructorsGetAll");
            List<Instructor> retList = new List<Instructor>();
            try
            {
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read())
                {
                    retList.Add(new Instructor(dr));
                }
                comm.Connection.Close();
            }
            catch (Exception ex)
            {
                comm.Connection.Close();
            }
            return retList;
        }




        /// <summary>
        /// Attempts to add a database entry corresponding to the given Instructor
        /// </summary>
        /// <remarks></remarks>

        internal static int AddInstructor(Instructor obj)
        {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand("sproc_InstructorAdd");
            try
            {
                comm.Parameters.AddWithValue("@" + Instructor.db_FirstName, obj.FirstName);
                comm.Parameters.AddWithValue("@" + Instructor.db_LastName, obj.LastName);
                comm.Parameters.AddWithValue("@" + Instructor.db_Office, obj.Office);
                return AddObject(comm, "@" + Instructor.db_ID);
            }
            catch (Exception ex)
            {
            }
            return -1;
        }


        /// <summary>
        /// Attempts to the database entry corresponding to the given Instructor
        /// </summary>
        /// <remarks></remarks>

        internal static int UpdateInstructor(Instructor obj)
        {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand("sproc_InstructorUpdate");
            try
            {
                comm.Parameters.AddWithValue("@" + Instructor.db_ID, obj.ID);
                comm.Parameters.AddWithValue("@" + Instructor.db_FirstName, obj.FirstName);
                comm.Parameters.AddWithValue("@" + Instructor.db_LastName, obj.LastName);
                comm.Parameters.AddWithValue("@" + Instructor.db_Office, obj.Office);
                return UpdateObject(comm);
            }
            catch (Exception ex)
            {
            }
            return -1;
        }


        /// <summary>
        /// Attempts to delete the database entry corresponding to the Instructor
        /// </summary>
        /// <remarks></remarks>
        internal static int RemoveInstructor(Instructor obj)
        {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand();
            try
            {
                //comm.CommandText = //Insert Sproc Name Here;
                    comm.Parameters.AddWithValue("@" + Instructor.db_ID, obj.ID);
                return UpdateObject(comm);
            }
            catch (Exception ex)
            {
            }
            return -1;
        }


#endregion

#region Student
        /// <summary>
        /// Gets the INFO4430_Fall2020_MVC.Models.Student correposponding with the given ID
        /// </summary>
        /// <remarks></remarks>

        public static Student GetStudent(String idstring, Boolean retNewObject)
        {
            Student retObject = null;
            int ID;
            if (int.TryParse(idstring, out ID))
            {
                if (ID == -1 && retNewObject)
                {
                    retObject = new Student();
                    retObject.ID = -1;
                }
                else if (ID >= 0)
                {
                    retObject = GetStudent(ID);
                }
            }
            return retObject;
        }


        /// <summary>
        /// Gets the INFO4430_Fall2020_MVC.Models.Studentcorresponding with the given ID
        /// </summary>
        /// <remarks></remarks>

        public static Student GetStudent(int id)
        {
            SqlCommand comm = new SqlCommand("sprocStudentGet");
            Student retObj = null;
            try
            {
                comm.Parameters.AddWithValue("@" + Student.db_ID, id);
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read())
                {
                    retObj = new Student(dr);
                }
                comm.Connection.Close();
            }
            catch (Exception ex)
            {
                comm.Connection.Close();
            }
            return retObj;
        }


        /// <summary>
        /// Gets a list of all INFO4430_Fall2020_MVC.Models.Student objects from the database.
        /// </summary>
        /// <remarks></remarks>
        public static List<Student> GetStudents()
        {
            SqlCommand comm = new SqlCommand("sprocStudentsGetAll");
            List<Student> retList = new List<Student>();
            try
            {
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read())
                {
                    retList.Add(new Student(dr));
                }
                comm.Connection.Close();
            }
            catch (Exception ex)
            {
                comm.Connection.Close();
            }
            return retList;
        }




        /// <summary>
        /// Attempts to add a database entry corresponding to the given Student
        /// </summary>
        /// <remarks></remarks>

        internal static int AddStudent(Student obj)
        {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand("sproc_StudentAdd");
            try
            {
                comm.Parameters.AddWithValue("@" + Student.db_FirstName, obj.FirstName);
                comm.Parameters.AddWithValue("@" + Student.db_LastName, obj.LastName);
                comm.Parameters.AddWithValue("@" + Student.db_Age, obj.Age);
                comm.Parameters.AddWithValue("@" + Student.db_NickName, obj.NickName);
                comm.Parameters.AddWithValue("@" + Student.db_FavoriteColor, obj.FavoriteColor);
                return AddObject(comm, "@" + Student.db_ID);
            }
            catch (Exception ex)
            {
            }
            return -1;
        }


        /// <summary>
        /// Attempts to the database entry corresponding to the given Student
        /// </summary>
        /// <remarks></remarks>

        internal static int UpdateStudent(Student obj)
        {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand("sproc_StudentUpdate");
            try
            {
                comm.Parameters.AddWithValue("@" + Student.db_ID, obj.ID);
                comm.Parameters.AddWithValue("@" + Student.db_FirstName, obj.FirstName);
                comm.Parameters.AddWithValue("@" + Student.db_LastName, obj.LastName);
                comm.Parameters.AddWithValue("@" + Student.db_Age, obj.Age);
                comm.Parameters.AddWithValue("@" + Student.db_NickName, obj.NickName);
                comm.Parameters.AddWithValue("@" + Student.db_FavoriteColor, obj.FavoriteColor);
                return UpdateObject(comm);
            }
            catch (Exception ex)
            {
            }
            return -1;
        }


        /// <summary>
        /// Attempts to delete the database entry corresponding to the Student
        /// </summary>
        /// <remarks></remarks>
        internal static int RemoveStudent(Student obj)
        {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand();
            try
            {
                //comm.CommandText = //Insert Sproc Name Here;
                    comm.Parameters.AddWithValue("@" + Student.db_ID, obj.ID);
                return UpdateObject(comm);
            }
            catch (Exception ex)
            {
            }
            return -1;
        }


#endregion

#region Course
        /// <summary>
        /// Gets the INFO4430_Fall2020_MVC.Models.Course correposponding with the given ID
        /// </summary>
        /// <remarks></remarks>

        public static Course GetCourse(String idstring, Boolean retNewObject)
        {
            Course retObject = null;
            int ID;
            if (int.TryParse(idstring, out ID))
            {
                if (ID == -1 && retNewObject)
                {
                    retObject = new Course();
                    retObject.ID = -1;
                }
                else if (ID >= 0)
                {
                    retObject = GetCourse(ID);
                }
            }
            return retObject;
        }


        /// <summary>
        /// Gets the INFO4430_Fall2020_MVC.Models.Coursecorresponding with the given ID
        /// </summary>
        /// <remarks></remarks>

        public static Course GetCourse(int id)
        {
            SqlCommand comm = new SqlCommand("sprocCourseGet");
            Course retObj = null;
            try
            {
                comm.Parameters.AddWithValue("@" + Course.db_ID, id);
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read())
                {
                    retObj = new Course(dr);
                }
                comm.Connection.Close();
            }
            catch (Exception ex)
            {
                comm.Connection.Close();
            }
            return retObj;
        }


        /// <summary>
        /// Gets a list of all INFO4430_Fall2020_MVC.Models.Course objects from the database.
        /// </summary>
        /// <remarks></remarks>
        public static List<Course> GetCourses()
        {
            SqlCommand comm = new SqlCommand("sprocCoursesGetAll");
            List<Course> retList = new List<Course>();
            try
            {
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = GetDataReader(comm);
                while (dr.Read())
                {
                    retList.Add(new Course(dr));
                }
                comm.Connection.Close();
            }
            catch (Exception ex)
            {
                comm.Connection.Close();
            }
            return retList;
        }




        /// <summary>
        /// Attempts to add a database entry corresponding to the given Course
        /// </summary>
        /// <remarks></remarks>

        internal static int AddCourse(Course obj)
        {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand("sproc_CourseAdd");
            try
            {
                comm.Parameters.AddWithValue("@" + Course.db_Name, obj.Name);
                comm.Parameters.AddWithValue("@" + Course.db_IndexNumber, obj.IndexNumber);
                comm.Parameters.AddWithValue("@" + Course.db_Professor, obj.InstructorID);
                return AddObject(comm, "@" + Course.db_ID);
            }
            catch (Exception ex)
            {
            }
            return -1;
        }


        /// <summary>
        /// Attempts to the database entry corresponding to the given Course
        /// </summary>
        /// <remarks></remarks>

        internal static int UpdateCourse(Course obj)
        {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand("sproc_CourseUpdate");
            try
            {
                comm.Parameters.AddWithValue("@" + Course.db_ID, obj.ID);
                comm.Parameters.AddWithValue("@" + Course.db_Name, obj.Name);
                comm.Parameters.AddWithValue("@" + Course.db_IndexNumber, obj.IndexNumber);
                comm.Parameters.AddWithValue("@" + Course.db_Professor, obj.InstructorID);
                return UpdateObject(comm);
            }
            catch (Exception ex)
            {
            }
            return -1;
        }


        /// <summary>
        /// Attempts to delete the database entry corresponding to the Course
        /// </summary>
        /// <remarks></remarks>
        internal static int RemoveCourse(Course obj)
        {
            if (obj == null) return -1;
            SqlCommand comm = new SqlCommand();
            try
            {
                //comm.CommandText = //Insert Sproc Name Here;
                    comm.Parameters.AddWithValue("@" + Course.db_ID, obj.ID);
                return UpdateObject(comm);
            }
            catch (Exception ex)
            {
            }
            return -1;
        }


        #endregion

        //#region CourseStudent
        //        /// <summary>
        //        /// Gets the INFO4430_Fall2020_MVC.Models.CourseStudent correposponding with the given ID
        //        /// </summary>
        //        /// <remarks></remarks>

        //        public static CourseStudent GetCourseStudent(String idstring, Boolean retNewObject)
        //        {
        //            CourseStudent retObject = null;
        //            int ID;
        //            if (int.TryParse(idstring, out ID))
        //            {
        //                if (ID == -1 && retNewObject)
        //                {
        //                    retObject = new CourseStudent();
        //                    retObject.ID = -1;
        //                }
        //                else if (ID >= 0)
        //                {
        //                    retObject = GetCourseStudent(ID);
        //                }
        //            }
        //            return retObject;
        //        }


        //        /// <summary>
        //        /// Gets the INFO4430_Fall2020_MVC.Models.CourseStudentcorresponding with the given ID
        //        /// </summary>
        //        /// <remarks></remarks>

        //        public static CourseStudent GetCourseStudent(int id)
        //        {
        //            SqlCommand comm = new SqlCommand("sprocCourseStudentGet");
        //            CourseStudent retObj = null;
        //            try
        //            {
        //                comm.Parameters.AddWithValue("@" + CourseStudent.db_ID, id);
        //                SqlDataReader dr = GetDataReader(comm);
        //                while (dr.Read())
        //                {
        //                    retObj = new CourseStudent(dr);
        //                }
        //                comm.Connection.Close();
        //            }
        //            catch (Exception ex)
        //            {
        //                comm.Connection.Close();
        //            }
        //            return retObj;
        //        }


        //        /// <summary>
        //        /// Gets a list of all INFO4430_Fall2020_MVC.Models.CourseStudent objects from the database.
        //        /// </summary>
        //        /// <remarks></remarks>
        //        public static List<CourseStudent> GetCourseStudents()
        //        {
        //            SqlCommand comm = new SqlCommand("sprocCourseStudentsGetAll");
        //            List<CourseStudent> retList = new List<CourseStudent>();
        //            try
        //            {
        //                comm.CommandType = CommandType.StoredProcedure;
        //                SqlDataReader dr = GetDataReader(comm);
        //                while (dr.Read())
        //                {
        //                    retList.Add(new CourseStudent(dr));
        //                }
        //                comm.Connection.Close();
        //            }
        //            catch (Exception ex)
        //            {
        //                comm.Connection.Close();
        //            }
        //            return retList;
        //        }




        //        /// <summary>
        //        /// Attempts to add a database entry corresponding to the given CourseStudent
        //        /// </summary>
        //        /// <remarks></remarks>

        //        internal static int AddCourseStudent(CourseStudent obj)
        //        {
        //            if (obj == null) return -1;
        //            SqlCommand comm = new SqlCommand("sproc_CourseStudentAdd");
        //            try
        //            {
        //                comm.Parameters.AddWithValue("@" + CourseStudent.db_Course, obj.Course);
        //                comm.Parameters.AddWithValue("@" + CourseStudent.db_Student, obj.Student);
        //                return AddObject(comm, "@" + CourseStudent.db_ID);
        //            }
        //            catch (Exception ex)
        //            {
        //            }
        //            return -1;
        //        }


        //        /// <summary>
        //        /// Attempts to the database entry corresponding to the given CourseStudent
        //        /// </summary>
        //        /// <remarks></remarks>

        //        internal static int UpdateCourseStudent(CourseStudent obj)
        //        {
        //            if (obj == null) return -1;
        //            SqlCommand comm = new SqlCommand("sproc_CourseStudentUpdate");
        //            try
        //            {
        //                comm.Parameters.AddWithValue("@" + CourseStudent.db_Course, obj.Course);
        //                comm.Parameters.AddWithValue("@" + CourseStudent.db_Student, obj.Student);
        //                return UpdateObject(comm);
        //            }
        //            catch (Exception ex)
        //            {
        //            }
        //            return -1;
        //        }


        //        /// <summary>
        //        /// Attempts to delete the database entry corresponding to the CourseStudent
        //        /// </summary>
        //        /// <remarks></remarks>
        //        internal static int RemoveCourseStudent(CourseStudent obj)
        //        {
        //            if (obj == null) return -1;
        //            SqlCommand comm = new SqlCommand();
        //            try
        //            {
        //                //comm.CommandText = //Insert Sproc Name Here;
        //                    comm.Parameters.AddWithValue("@" + CourseStudent.db_ID, obj.ID);
        //                return UpdateObject(comm);
        //            }
        //            catch (Exception ex)
        //            {
        //            }
        //            return -1;
        //        }


        //#endregion

    }
}
