using EmployeeInfos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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

        public List<Employee> FindByProperty(string propertyName, string value)
        {
            var allEmployees = GetEmployeeDetails();
            Type type = allEmployees[0].GetType();
            PropertyInfo info = type.GetProperty(propertyName);
            var employeeList = allEmployees.Where(x=> Convert.ToString(info.GetValue(x)) == value).ToList();
            return employeeList;
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
    }
}
