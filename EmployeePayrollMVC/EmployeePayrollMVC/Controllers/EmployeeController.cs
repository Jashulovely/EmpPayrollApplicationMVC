using ManagerLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
        [Route("Register")]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
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
        [Route("Details")]
        public IActionResult Details(int id)
        {
            try
            {
                id = (int)HttpContext.Session.GetInt32("EmpId");
            }catch(Exception e){
                return RedirectToAction("Login");
                throw e;
            }
            EmployeeModel employee = manager.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpGet]
        //[Route("DetailsByName/{name}")]
        public IActionResult DetailsByName(string name)
        {
            try
            {
                name = HttpContext.Session.GetString("EmpName");
            }
            catch (Exception e)
            {
                return RedirectToAction("Login");
                throw e;
            }
            EmployeeModel employee = manager.GetEmployeeDataByName(name);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }




        [HttpGet]
        //[Route("RegisterOrUpdate")]
        public IActionResult InsertOrUpdateEmployee()
        {
            return View();
        }

        [HttpPost]
        //[Route("RegisterOrUpdate")]
        public IActionResult InsertOrUpdateEmployee([Bind] EmployeeModel employee)
        {
            EmployeeModel model = new EmployeeModel();
            if (ModelState.IsValid)
            {
                model = manager.InsertOrUpdate(employee);
                return RedirectToAction("AllEmployees");
            }
            return View(model);
        }




        [HttpGet]
        [Route("Update/{id}")]
        public IActionResult Edit(int id)
        {
            try
            {
                id = (int)HttpContext.Session.GetInt32("EmpId");
            }
            catch (Exception e)
            {
                return RedirectToAction("Login");
                throw e;
            }
            EmployeeModel employee = manager.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [Route("Update/{id}")]
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
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                id = (int)HttpContext.Session.GetInt32("EmpId");
            }
            catch (Exception e)
            {
                return RedirectToAction("Login");
                throw e;
            }
            EmployeeModel employee = manager.GetEmployeeData(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [Route("Delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            manager.DeleteEmployee(id);
            return RedirectToAction("AllEmployees");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(EmpLoginModel login)
        {
            var emp = manager.EmpLogin(login);
            if (emp != null)
            {
                HttpContext.Session.SetInt32("EmpId", emp.EmpId);
                HttpContext.Session.SetString("EmpName", emp.EmpName);
                return RedirectToAction("Details");
            }
            else
            {
                return RedirectToAction("AllEmployees");
            }
        }
        
    }
}
