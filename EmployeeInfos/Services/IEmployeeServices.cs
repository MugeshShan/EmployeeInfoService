using EmployeeInfos.Models;
using System.Collections.Generic;

namespace EmployeeInfos.Services
{
    public interface IEmployeeServices
    {
        List<Employee> GetAllEmployess();

        Employee GetEmployeeById(int id);
        bool DeleteEmployee(Employee employee);

        bool UpdateEmployee(Employee updateEmployee);
        void AddEmployee(Employee employee);
        List<Employee> FindByProperty(string propertyName, string value);

        List<DataPoints> GetEmployeeRegistrationByMonth();
    }
}
