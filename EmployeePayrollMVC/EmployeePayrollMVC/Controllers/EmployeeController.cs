using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeManager manager;
        public EmployeeController(IEmployeeManager manager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee([Bind] EmployeeModel employee)
        {
            EmployeeModel model = new EmployeeModel();  
            if (ModelState.IsValid)
            {
                model = manager.AddEmployee(employee);
                return RedirectToAction("AllEmployees");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AllEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
                employees = manager.GetAllEmployees().ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = manager.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind] EmployeeModel employee)
        {
            if (id != employee.EmpId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                manager.UpdateEmployee(employee);
                return RedirectToAction("AllEmployees");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employee = manager.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            manager.DeleteEmployee(id);
            return RedirectToAction("AllEmployees");
        }
    }
}
