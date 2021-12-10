using EmployeeInfos.Models;
using System.Collections.Generic;

namespace EmployeeInfos.Services
{
    /// <summary>
    /// Interface for the Employee Service Class
    /// </summary>
    public interface IEmployeeServices
    {
        /// <summary>
        /// Method to get all employee
        /// </summary>
        /// <returns>Employee List</returns>
        List<Employee> GetAllEmployess();

        /// <summary>
        /// Method to get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee</returns>
        Employee GetEmployeeById(int id);


        /// <summary>
        /// Method to delete the employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>True or False</returns>
        bool DeleteEmployee(Employee employee);

        /// <summary>
        /// Method to update the employee
        /// </summary>
        /// <param name="updateEmployee"></param>
        /// <returns>True or False</returns>
        bool UpdateEmployee(Employee updateEmployee);

        /// <summary>
        /// Method to add employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>True or False</returns>
        bool AddEmployee(Employee employee);

        /// <summary>
        /// Get Employee Details by Property Name
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns>Employee list</returns>
        List<Employee> FindByProperty(string propertyName, string value);

        /// <summary>
        /// Method to get employee registration by month
        /// </summary>
        /// <returns>Number of employee and Month</returns>
        List<DataPoints> GetEmployeeRegistrationByMonth();
    }
}
