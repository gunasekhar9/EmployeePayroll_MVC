using BusinessLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollMVC.Controllers
{
    
    public class EmployeeController : Controller
    {
        IUserBL userBL;
        public EmployeeController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        public IActionResult Index()
        {
            List<Employeemodel> employeemodels = new List<Employeemodel>();
            employeemodels = this.userBL.GetEmployeemodels().ToList();
            return View(employeemodels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employeemodel employee)
        {
            if (ModelState.IsValid)
            {
                userBL.addEmployee(employee);
                return RedirectToAction("Create");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employeemodel employeemodel = userBL.GetEmployeemodel(id);

            if (employeemodel == null)
            {
                return NotFound();
            }
            return View(employeemodel);
        }

        [HttpGet]
        public IActionResult deleteEmployee(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employeemodel employeemodel = userBL.GetEmployeemodel(id);

            if (employeemodel == null)
            {
                return NotFound();
            }
            return View(employeemodel);
        }

        [HttpPost, ActionName("deleteEmployee")]
        public IActionResult DeleteConfirmed(int? id)
        {
            userBL.deleteEmployee(userBL.GetEmployeemodel(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employeemodel employee = userBL.GetEmployeemodel(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(int id, Employeemodel employee)
        {
            if (id != employee.emp_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                userBL.updateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

    }
}
