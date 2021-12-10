using EmployeeInfos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EmployeeInfos.Services
{
    /// <summary>
    /// Employee Services class
    /// </summary>
    public class EmployeeServices : IEmployeeServices
    {
        /// <summary>
        /// Method to get all employee
        /// </summary>
        /// <returns>Employee List</returns>
        public List<Employee> GetAllEmployess()
        {
            return GetEmployeeDetails();
        }

        /// <summary>
        /// Method to get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee</returns>
        public Employee GetEmployeeById(int id)
        {
            var allEmployees = GetEmployeeDetails();
            return allEmployees.Where(x => x.EmpId == id).Select(y => y).FirstOrDefault();
        }

        /// <summary>
        /// Get Employee Details by Property Name
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns>Employee list</returns>
        public List<Employee> FindByProperty(string propertyName, string value)
        {
            var allEmployees = GetEmployeeDetails();
            Type type = allEmployees[0].GetType();
            PropertyInfo info = type.GetProperty(propertyName);
            var employeeList = allEmployees.Where(x=> Convert.ToString(info.GetValue(x)) == value).ToList();
            return employeeList;
        }

        /// <summary>
        /// Method to add employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>True or False</returns>
        public bool AddEmployee(Employee employee)
        {
            try
            {
                var allEmployees = GetEmployeeDetails();
                var id = allEmployees.Last().EmpId + 1;
                employee.EmpId = id;
                allEmployees.Add(employee);
                WriteEmployeeDetailsJson(allEmployees);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Method to update the employee
        /// </summary>
        /// <param name="updateEmployee"></param>
        /// <returns>True or False</returns>
        public bool UpdateEmployee(Employee updateEmployee)
        {
            try
            {
                var allEmployees = GetEmployeeDetails();
                allEmployees.ForEach(x =>
                {
                    if (x.EmpId == updateEmployee.EmpId)
                    {
                        x.FirstName = updateEmployee.FirstName;
                        x.LastName = updateEmployee.LastName;
                        x.DOB = updateEmployee.DOB;
                        x.Designation = updateEmployee.Designation;
                        x.HourlyRate = updateEmployee.HourlyRate;
                        x.StartDate = updateEmployee.StartDate;
                        x.EndDate = updateEmployee.EndDate;
                        x.ManagerId = updateEmployee.ManagerId;
                        x.Department = updateEmployee.Department;
                    }
                });
                WriteEmployeeDetailsJson(allEmployees);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Method to delete the employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>True or False</returns>
        public bool DeleteEmployee(Employee employee)
        {
            try
            {
                var allEmployees = GetEmployeeDetails();
                var count = allEmployees.RemoveAll(x => x.EmpId == employee.EmpId);
                WriteEmployeeDetailsJson(allEmployees);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Method to get employee registration by month
        /// </summary>
        /// <returns>Number of employee and Month</returns>
        public List<DataPoints> GetEmployeeRegistrationByMonth()
        {
            List<DataPoints> dataPoints = new List<DataPoints>();
            dataPoints.Add(new DataPoints("Jan", 72));
            dataPoints.Add(new DataPoints("Feb", 67));
            dataPoints.Add(new DataPoints("Mar", 55));
            dataPoints.Add(new DataPoints("Apr", 42));
            dataPoints.Add(new DataPoints("May", 40));
            dataPoints.Add(new DataPoints("Jun", 35));

            dataPoints.Add(new DataPoints("Jul", 48));
            dataPoints.Add(new DataPoints("Aug", 56));
            dataPoints.Add(new DataPoints("Sep", 50));
            dataPoints.Add(new DataPoints("Oct", 47));
            dataPoints.Add(new DataPoints("Nov", 65));
            dataPoints.Add(new DataPoints("Dec", 69));

            return dataPoints;
        }

        /// <summary>
        /// Private method to read employee details from json
        /// </summary>
        /// <returns></returns>
        private List<Employee> GetEmployeeDetails()
        {
            using (var streamReader = new StreamReader(@"Models\EmployeeDetails.json"))
            {
                string accountDetailsJson = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<EmployeeDetails>(accountDetailsJson).Employees;
            };
        }

        /// <summary>
        /// Write Employee details into the json
        /// </summary>
        /// <param name="employeeList"></param>
        private void WriteEmployeeDetailsJson(List<Employee> employeeList)
        {
            var employeeDetails = new EmployeeDetails();
            employeeDetails.Employees = employeeList;
            using (var streamWriter = new StreamWriter(@"Models\EmployeeDetails.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(streamWriter, employeeDetails);
            };
        }
    }
}
