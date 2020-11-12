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
    public class StudentController : Controller
    {

        public StudentController()
        {
        
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Student.ToListAsync());
            return View(DAL.GetStudents());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var student = await _context.Student
            //    .FirstOrDefaultAsync(m => m.ID == id);
            Student student = DAL.GetStudent((int)id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Age,NickName,FavoriteColor,ID")] Student student)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(student);
                //await _context.SaveChangesAsync();
                DAL.AddStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var student = await _context.Student.FindAsync(id);
            Student student = DAL.GetStudent((int)id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Age,NickName,FavoriteColor,ID")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(student);
                    //await _context.SaveChangesAsync();
                    DAL.UpdateStudent(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!StudentExists(student.ID))
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
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var student = await _context.Student
            //    .FirstOrDefaultAsync(m => m.ID == id);
            Student student = DAL.GetStudent((int)id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var student = await _context.Student.FindAsync(id);
            //_context.Student.Remove(student);
            //await _context.SaveChangesAsync();
            Student student = DAL.GetStudent((int)id);
            DAL.RemoveStudent(student);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
