using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstDbMVCApp.Data;
using FirstDbMVCApp.Models;

namespace FirstDbMVCApp.Controllers
{
    public class CoursesController : Controller
    {
        private readonly FirstDbMVCAppContext _db;

        public CoursesController(FirstDbMVCAppContext db)
        {
            _db = db;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            // Checking if the table Course exists in the database. 
              return _db.Course != null ? 
                          View(await _db.Course.ToListAsync()) :
                          Problem("Entity set 'FirstDbMVCAppContext.Course'  is null.");
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.Course == null)
            {
                return NotFound();
            }

            Course course = await _db.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title")] Course course)
        {
            if (ModelState.IsValid)
            {
                _db.Add(course);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        // First: This is showing the course to be edited
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.Course == null)
            {
                return NotFound();
            }

            var course = await _db.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // Second: This is creating the view to get the data modified by the user
        // and post it to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(course);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.Course == null)
            {
                return NotFound();
            }

            var course = await _db.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.Course == null)
            {
                return Problem("Entity set 'FirstDbMVCAppContext.Course'  is null.");
            }
            var course = await _db.Course.FindAsync(id);
            if (course != null)
            {
                _db.Course.Remove(course);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
          return (_db.Course?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
