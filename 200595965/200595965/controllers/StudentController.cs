using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using _200595965.Models; 

namespace _200595965.Controllers 
{
    public class StudentController : Controller
    {
        private static List<Student> _students = new List<Student>
        {
            new Student { StudentId = 1, FirstName = "Nitin", LastName = "Kumar", EmailAddress = "nitin0875@gmail.com" },
            new Student { StudentId = 2, FirstName = "Vansh", LastName = "singh", EmailAddress = "vannu69@gmail.com" },
            new Student { StudentId = 3, FirstName = "Amritpal", LastName = "denali", EmailAddress = "denali0001@gmail.com" }
        };

        public IActionResult Index()
        {
            return View(_students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.StudentId = _students.Count + 1; 
                _students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = _students.FirstOrDefault(s => s.StudentId == student.StudentId);
                if (existingStudent != null)
                {
                    existingStudent.FirstName = student.FirstName;
                    existingStudent.LastName = student.LastName;
                    existingStudent.EmailAddress = student.EmailAddress;
                }
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == id);
            if (student != null)
            {
                _students.Remove(student);
            }
            return RedirectToAction("Index");
        }
    }
}