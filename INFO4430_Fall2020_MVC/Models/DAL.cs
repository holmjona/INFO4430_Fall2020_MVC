using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFO4430_Fall2020_MVC.Models {
    public static class DAL {
        private static List<User> _Users = null;


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

    }
}
