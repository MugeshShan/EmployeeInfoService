using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfos.Models
{
    public class EmployeeDetails
    {
        [JsonProperty("employeeDetails")]
        public List<Employee>Employees { get; set; }
    }
}
