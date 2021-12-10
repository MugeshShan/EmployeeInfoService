using EmployeeInfos.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeInfos.Controllers
{
    /// <summary>
    /// Chart Controller
    /// </summary>
    public class ChartController : Controller
    {
        private readonly IEmployeeServices employeeServices;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_employeeServices"></param>
        public ChartController(IEmployeeServices _employeeServices)
        {
            employeeServices = _employeeServices;
        }

        /// <summary>
        /// Index mothod to show the chart
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var datapoints = employeeServices.GetEmployeeRegistrationByMonth();
            ViewBag.DataPoints = datapoints;
            return View(datapoints);
        }
    }
}
