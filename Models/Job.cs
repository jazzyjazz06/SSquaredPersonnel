using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSquaredPersonnel.Models
{
    public class Job
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int RoleID { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
    }
}