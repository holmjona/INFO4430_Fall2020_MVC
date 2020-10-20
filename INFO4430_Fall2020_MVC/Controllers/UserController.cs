﻿using System;
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

        public IActionResult Details(int id) {
            User myUser = DAL.GetUser(id);
            return View("Details", myUser);
        }
    }
}