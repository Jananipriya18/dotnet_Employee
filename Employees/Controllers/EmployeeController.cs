using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "John Doe", Email = "john@example.com", Dob = new DateTime(1990, 5, 15), Dept = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Dob = new DateTime(1985, 10, 20), Dept = "HR", Salary = 60000 }
        };

        public IActionResult Index()
        {
            return View(_employees);
        }

        public IActionResult Details(int id)
        {
            var employee = _employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = _employees.Count + 1; // Assign new ID
                _employees.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var employee = _employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = _employees.Find(e => e.Id == employee.Id);
                if (existingEmployee == null)
                {
                    return NotFound();
                }
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                existingEmployee.Dob = employee.Dob;
                existingEmployee.Dept = employee.Dept;
                existingEmployee.Salary = employee.Salary;
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            var employee = _employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _employees.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _employees.Remove(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
