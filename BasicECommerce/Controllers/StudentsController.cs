using FirstDbMVCApp.Data;
using FirstDbMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstDbMVCApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FirstDbMVCApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly FirstDbMVCAppContext _db;

        public StudentsController(FirstDbMVCAppContext db)
        {
            _db = db;
        }

        // GET: Students
        public IActionResult Index()
        {

            if(_db.Student == null)
            {
                return NotFound();
            } else
            {
                HashSet<Student> allStudents = _db.Student.Include(s => s.Course).ToHashSet();
                return View(allStudents);
            }
        }

        // GET: Students/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null || _db.Student == null)
            {
                return NotFound();
            }

            Student student = _db.Student.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            // in create method, add a dropdown list of all courses names
            HashSet<Course> courses = _db.Course.ToHashSet();

            CUStudentVM vm = new CUStudentVM(courses);
            vm.NewStudent = new Student();
            
            return View(vm);
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult Create([Bind("Id, FullName, CourseId")] Student student, int CourseId)
        public IActionResult Create(CUStudentVM vm)
        {

            Student student = vm.NewStudent;
            student.CourseId = vm.SelectedCourseId;

            if (ModelState.IsValid)
            {
                _db.Student.Add(student);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }
        }

            /*
            if (ModelState.IsValid)
            {
                
                student.Id = Guid.NewGuid();
                _db.Add(student);
                _db.SaveChanges();
                student.Course = _db.Course.FirstOrDefault(c => c.Id == CourseId);
                student.CourseId = CourseId;
                _db.Update(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
                _db.Student.Add(student);
                _db.SaveChanges();
            }
            return View(student);
        }
          */

            // GET: Students/Edit/5
            public IActionResult Edit(Guid? id)
        {
            if (id == null || _db.Student == null || _db.Course == null)
            {
                return NotFound();
            }

            Student student = _db.Student.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            CUStudentVM vm = new CUStudentVM(_db.Course.ToHashSet());
            vm.SelectedCourseId = student.CourseId;
            vm.NewStudent = student;
            return View(vm);
        }

        // POST: Student/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CUStudentVM vm)
        {
            Student student = vm.NewStudent;
            student.CourseId = vm.SelectedCourseId;

                if (ModelState.IsValid)
                {
                    _db.Student.Update(student);
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                } else
                {
                    return Problem("Error handling Student entity changes.");
                }
            }

        // GET: Students/Delete
        public IActionResult Delete(Guid? id)
        {
            if (id == null || _db.Student == null)
            {
                return NotFound();
            }

            Student student = _db.Student.FirstOrDefault(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            if (_db.Student == null)
            {
                return Problem("Entity set 'FirstDbMVCAppContext.Student'  is null.");
            }

            Student student = _db.Student.Find(id);
            if (student != null)
            {
                _db.Student.Remove(student);
            }

            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(Guid id)
        {
            return (_db.Student?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
