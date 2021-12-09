using EmployeeInfos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeeInfos.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        public List<Employee> GetAllEmployess()
        {
            return GetEmployeeDetails();
        }

        public Employee GetEmployeeById(int id)
        {
            var allEmployees = GetEmployeeDetails();
            return allEmployees.Where(x => x.EmpId == id).Select(y => y).FirstOrDefault();
        }
        private List<Employee> GetEmployeeDetails()
        {
            using (var streamReader = new StreamReader(@"Models\EmployeeDetails.json"))
            {
                string accountDetailsJson = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<EmployeeDetails>(accountDetailsJson).Employees;
            };
        }

        public void AddEmployee(Employee employee)
        {
            var allEmployees = GetEmployeeDetails();
            var id = allEmployees.Last().EmpId + 1;
            employee.EmpId = id;
            allEmployees.Add(employee);
            WriteEmployeeDetailsJson(allEmployees);
        }

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
    }
}
