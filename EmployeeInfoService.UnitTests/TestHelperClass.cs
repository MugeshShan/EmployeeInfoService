using EmployeeInfos.Models;
using System.Collections.Generic;

namespace EmployeeInfoService.UnitTests
{
    /// <summary>
    /// Helper Class for Test
    /// </summary>
    public class TestHelperClass
    {
        /// <summary>
        /// Method to get all employees
        /// </summary>
        /// <returns></returns>
        public static List<Employee> GetAllEmployees()
        {
            var emp1 = new Employee
            {
                EmpId = 1,
                FirstName = "Mugesh",
                LastName = "S",
                HourlyRate = "$1000",
                Department = "Engineering"
            };

            var emp2 = new Employee
            {
                EmpId = 2,
                FirstName = "Prakash",
                LastName = "M",
                HourlyRate = "$1000",
                Department = "Engineering"
            };

            var empList = new List<Employee>();
            empList.Add(emp1);
            empList.Add(emp2);
            return empList;
        }

        /// <summary>
        /// Method to get Employee
        /// </summary>
        /// <returns></returns>
        public static Employee GetEmployee()
        {
            return new Employee
            {
                EmpId = 3,
                FirstName = "Bhaskar",
                LastName = "Cheede",
                HourlyRate = "$1000",
                Department = "Engineering"
            };
        }
    }
}
