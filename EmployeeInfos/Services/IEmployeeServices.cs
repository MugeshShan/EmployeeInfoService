using EmployeeInfos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfos.Services
{
    public interface IEmployeeServices
    {
        List<Employee> GetAllEmployess();

        Employee GetEmployeeById(int id);
        bool DeleteEmployee(Employee employee);

        bool UpdateEmployee(Employee updateEmployee);
        void AddEmployee(Employee employee);
    }
}
