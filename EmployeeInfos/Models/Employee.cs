using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfos.Models
{
    public class Employee
    {
        public int EmpId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DOB { get; set; }

        public string HourlyRate { get; set; }

        public string Designation { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int ManagerId { get; set; }

        public string Department { get; set; }
    }
}
