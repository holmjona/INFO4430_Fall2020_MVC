using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFO4430_Fall2020_MVC.Models {
    public static class DAL {
        private static List<User> _Users = null;
        private const string connectionString = "Server=localhost; Database=4430Demo;Trusted_Connection=True;";


        public static List<User> GetUsers() {
            if (_Users == null) {
                PopulateUsers();
            }
            return _Users;
        }

        private static void PopulateUsers() {
            _Users = new List<User>();
            _Users.Add(new Models.User() {ID=1, FirstName = "Ry", LastName = "O",IsAwesome = true });
            _Users.Add(new Models.User() {ID=2, FirstName = "Brandon", LastName = "W", IsAwesome = true });
            _Users.Add(new Models.User() {ID=3, FirstName = "Jon", LastName = "H" });
        }

        public static User GetUser(int id) {
            User userFound = _Users.FirstOrDefault(u => u.ID == id);
            return userFound;
        }

        public static List<Course> GetCourses() {
            List<Course> retList = new List<Course>();

            SqlConnection conn = null;
            try {
                conn = new SqlConnection(connectionString);
                //conn.ConnectionString = connectionString;
                //SqlCommand comm = new SqlCommand();
                //comm.Connection = conn;
                //comm.CommandText = "sprocCoursesGetAll";
                //comm.CommandType = System.Data.CommandType.StoredProcedure;

                SqlCommand comm = new SqlCommand("sprocCoursesGetAll", conn);
                comm.CommandType = System.Data.CommandType.StoredProcedure;

                //comm.ExecuteNonQuery(); // queries that do not return a table result.
                //comm.ExecuteScalar(); // queries that only have a single column and row table

                conn.Open();
                //comm.Connection.Open();
                SqlDataReader dr = comm.ExecuteReader(); // queries that get data from the database.
                while (dr.Read()) {
                    Course newCourse = new Course();
                    newCourse.ID = (int)dr["CourseID"];
                    newCourse.Name = (string)dr["Name"];
                    newCourse.IndexNumber = (int)dr["IndexNumber"];
                    newCourse.InstructorID = (int)dr["ProfessorID"];
                    retList.Add(newCourse);
                }
            } catch (Exception ex) {
                System.Diagnostics.Debug.Write(ex.Message);
            } finally {
                if (conn != null) conn.Close();
            }
            return retList;
        }


        public static Course GetCourse(int id) {
            Course retObj = null;

            SqlConnection conn = null;
            try {
                conn = new SqlConnection(connectionString);
            
                SqlCommand comm = new SqlCommand("sprocCourseGet", conn);
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@CourseID", id);
                                
                conn.Open();
                //comm.Connection.Open();
                SqlDataReader dr = comm.ExecuteReader(); // queries that get data from the database.
                while (dr.Read()) {
                    Course newCourse = new Course();
                    newCourse.ID = (int)dr["CourseID"];
                    newCourse.Name = (string)dr["Name"];
                    newCourse.IndexNumber = (int)dr["IndexNumber"];
                    newCourse.InstructorID = (int)dr["ProfessorID"];
                    retObj = newCourse;
                }
            } catch (Exception ex) {
                System.Diagnostics.Debug.Write(ex.Message);
            } finally {
                if (conn != null) conn.Close();
            }
            return retObj;
        }

    }
}
