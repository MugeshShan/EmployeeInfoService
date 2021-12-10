using EmployeeInfos.Models;
using EmployeeInfos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeInfos.Controllers
{
    /// <summary>
    /// Employee Controller
    /// </summary>
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_employeeServices"></param>
        public EmployeeController(IEmployeeServices _employeeServices)
        {
            employeeServices = _employeeServices;
        }

        /// <summary>
        /// Controller method to get all employee details
        /// </summary>
        /// <returns></returns>
        // GET: EmployeeController
        public ActionResult Index()
        {
            var employees = employeeServices.GetAllEmployess();
            if(employees.Count == 0)
            {
                return NotFound();
            }
            return View(employees);
        }

        /// <summary>
        /// Controller method to get employee details by property name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(int? id)
        {
            var selectedProperty = Request.Form["FindBy"].ToString();
            var value = Request.Form["findByValue"].ToString();
            var employees = employeeServices.FindByProperty(selectedProperty, value);
            return View(employees); ;
        }

        /// <summary>
        /// COntroller method to get employee details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Controller method to create a new employee
        /// </summary>
        /// <returns></returns>
        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post Controller method to create a employee
        /// </summary>
        /// <param name="employeeData"></param>
        /// <returns></returns>
        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("FirstName,LastName,DOB,Designation,HourlyRate,StartDate,EndDate,ManagerId,Department")] Employee employeeData)
        {
            try
            {
                if (employeeServices.AddEmployee(employeeData))
                {
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Controller method to get the employee by id for edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Controller method to edit the employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeData"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Controller method to get employee by id for delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = employeeServices.GetEmployeeById(id);
            return View(employee);
        }

        /// <summary>
        /// Controller method to delete the employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
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
