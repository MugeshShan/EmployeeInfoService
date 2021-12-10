using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmployeeInfos.Models
{
    /// <summary>
    /// Class for Employee Details
    /// </summary>
    public class EmployeeDetails
    {
        /// <summary>
        /// List of Employee Object
        /// </summary>
        [JsonProperty("employeeDetails")]
        public List<Employee>Employees { get; set; }
    }
}
