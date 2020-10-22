using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using INFO4430_Fall2020_MVC.Models;

namespace INFO4430_Fall2020_MVC.Controllers {
    public class SandwichController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Make(string type, int? stack) {
            //string myType = Request.Query["type"];
            Sandwich yum = new Sandwich();
            yum.PattyCount = 1;
            if (stack != null) {
                yum.PattyCount = (int)stack > 0 ? (int)stack : 1;
            }
            if (type == "Chicken") {
                yum.Type = Sandwich.Types.Chicken;
            }else if (type == "Burger") {
                yum.Type = Sandwich.Types.Burger;
            }else if (type == "Meatless") {
                yum.Type = Sandwich.Types.Meatless;
            } else {

            }
            return View(yum);
        }
    }
}
