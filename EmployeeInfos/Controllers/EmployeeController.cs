using EmployeeInfos.Models;
using EmployeeInfos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeeInfos.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;
        public EmployeeController(IEmployeeServices _employeeServices)
        {
            employeeServices = _employeeServices;
        }
        // GET: EmployeeController
        public ActionResult Index(int? id)
        {
            var employees = employeeServices.GetAllEmployess();
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var employee = employeeServices.GetEmployeeById((int)id);
            if(employee == null )
            {
                return NotFound();
            };
            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("FirstName,LastName,DOB,Designation,HourlyRate,StartDate,EndDate,ManagerId,Department")] Employee employeeData)
        {
            try
            {
                employeeServices.AddEmployee(employeeData);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.IsEdit = id == null ? false : true;
            if (id == null)
            {
                return View();
            }
            var employee = employeeServices.GetEmployeeById((int)id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("EmpId,FirstName,LastName,DOB,Designation,HourlyRate,StartDate,EndDate,ManagerId,Department")] Employee employeeData)
        {
            bool isEmployeeExist = false;
            var employee = employeeServices.GetEmployeeById((int)id);
            if (employee != null)
            {
                isEmployeeExist = true;
            }
            else
            {
                employee = new Employee();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    employee.EmpId = employeeData.EmpId;
                    employee.FirstName = employeeData.FirstName;
                    employee.LastName = employeeData.LastName;
                    employee.DOB = employeeData.DOB;
                    employee.Designation = employeeData.Designation;
                    employee.HourlyRate = employeeData.HourlyRate;
                    employee.StartDate = employeeData.StartDate;
                    employee.EndDate = employeeData.EndDate;
                    employee.ManagerId = employeeData.ManagerId;
                    employee.Department = employeeData.Department;
                    if (employeeServices.UpdateEmployee(employee))
                    {

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View();
                    }
                }
                catch
                {
                    return View();
                }
            }
            
            return RedirectToAction(nameof(Index));
            
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = employeeServices.GetEmployeeById(id);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var employee = employeeServices.GetEmployeeById(id);
                if(employee == null)
                {
                    return NotFound();
                }
                var isDeleted = employeeServices.DeleteEmployee(employee);
                if (isDeleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            catch
            {
                return View();
            }
        }
    }
}
