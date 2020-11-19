using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INFO4430_Fall2020_MVC.Data;
using INFO4430_Fall2020_MVC.Models;

namespace INFO4430_Fall2020_MVC.Controllers
{
    public class CourseController : Controller
    {
        
        public CourseController()
        {
            
        }

        // GET: Course
        public async Task<IActionResult> Index()
        {
            //MD5
            //SHA-1
            //SHA-128
            //SHA-256

            //PBKDF2


            //User curUser = new User();
            ////if (!curUser.hasPermission) {
            //    return RedirectToAction("Index", "Home");
            ////}

            List<Course> lst = DAL.GetCourses();
            return View(lst);
            
        }

        // GET: Course/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = DAL.GetCourse((int)id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,IndexNumber,InstructorID")] Course course)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(course);
                //await _context.SaveChangesAsync();
                DAL.AddCourse(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Course course = DAL.GetCourse((int)id);
            //var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,IndexNumber,InstructorID")] Course course)
        {
            if (id != course.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //validate here first
                    //Course oriCourse = DAL.GetCourse(id);
                    //_context.Update(course);
                    //await _context.SaveChangesAsync();
                    DAL.UpdateCourse(course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!CourseExists(course.ID))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var course = await _context.Course
            //    .FirstOrDefaultAsync(m => m.ID == id);
            Course course = DAL.GetCourse((int)id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var course = await _context.Course.FindAsync(id);
            Course course = DAL.GetCourse((int)id);
            //_context.Course.Remove(course);
            DAL.RemoveCourse(course);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool CourseExists(int id)
        //{
        //    return _context.Course.Any(e => e.ID == id);
        //}

        [HttpPost]
        public ActionResult Search(string searchText) {
            List<Course> crses = DAL.GetCourses();
            searchText = searchText.ToLower();
            List<object> retObjs = new List<object>();
            foreach (Course crs in crses) {
                if (crs.Name.ToLower().Contains(searchText)) {
                    retObjs.Add(new { name = crs.Name, id = crs.ID });
                }
            }

            return Json(retObjs);
        }

    }
}
