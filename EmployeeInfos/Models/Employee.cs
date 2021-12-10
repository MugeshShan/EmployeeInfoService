using System.ComponentModel.DataAnnotations;

namespace EmployeeInfos.Models
{
    /// <summary>
    /// Class for Employee
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Employee Id
        /// </summary>
        public int EmpId { get; set; }

        [Required]
        [Display(Name = "Employee First Name")]
        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Employee Last Name")]
        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Employee Date of Birth")]
        /// <summary>
        /// Date of Birth
        /// </summary>
        public string DOB { get; set; }

        [Display(Name = "Employee HourlyRate")]
        [Required]
        /// <summary>
        /// Hourly Rate
        /// </summary>
        public string HourlyRate { get; set; }

        [Display(Name = "Employee Designation")]
        [Required]
        /// <summary>
        /// Designation
        /// </summary>
        public string Designation { get; set; }

        [Display(Name = "Employee Start Date")]
        [Required]
        /// <summary>
        /// Start Date
        /// </summary>
        public string StartDate { get; set; }

        [Display(Name = "Employee Last Date")]
        [Required]
        /// <summary>
        /// End Date
        /// </summary>
        public string EndDate { get; set; }

        [Display(Name = "Employee Manager Id")]
        [Required]
        /// <summary>
        /// Manager Id
        /// </summary>
        public int ManagerId { get; set; }

        [Display(Name = "Employee Department")]
        [Required]
        /// <summary>
        /// Department
        /// </summary>
        public string Department { get; set; }
    }
}
