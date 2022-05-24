using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SSquaredPersonnel.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [DisplayName("Manager")]
        [ScaffoldColumn(false)]
        public int ManagerID { get; set; }
        
        [DisplayName("Employee ID")]
        public string Employee_ID { get; set; }
        
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Roles")]
        public ICollection<Job> Jobs { get; set; }
    }
}