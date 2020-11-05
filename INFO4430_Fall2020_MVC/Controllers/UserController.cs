using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFO4430_Fall2020_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace INFO4430_Fall2020_MVC.Controllers {
    public class UserController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult List() {

            return View(DAL.GetUsers());
        }

        public IActionResult Details(int? id) {
            if (id == null) {
                return NotFound();
            } else { // not null
                User myUser = DAL.GetUser((int)id);
                return View(myUser);
            }
        }


        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        //public ActionResult Create([Bind("FirstName", "LastName")] User usr) {
        public ActionResult Create(User usr) {
            if (ModelState.IsValid) {
                // Good data
                int a = 3;
            } else {
                // Bad data
                int a = 5;
            }
            return View();
        }
        //[HttpPost]
        //public ActionResult Create(int id, string firstName,string lastName) {
        //    User usr = new User();
        //    usr.ID = id;
        //    usr.FirstName = firstName;
        //    usr.LastName = Request.Form["LastName"];

        //    return View();
        //}



    }
}
