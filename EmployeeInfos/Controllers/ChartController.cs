using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeInfos.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeInfos.Controllers
{
    public class ChartController : Controller
    {
        private readonly IEmployeeServices employeeServices;
        public ChartController(IEmployeeServices _employeeServices)
        {
            employeeServices = _employeeServices;
        }
        public IActionResult Index()
        {
            var datapoints = employeeServices.GetEmployeeRegistrationByMonth();
            ViewBag.DataPoints = datapoints;
            return View(datapoints);
        }
    }
}
