using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SSquaredPersonnel.Models
{
    public class Role
    {
        public int RoleID { get; set; }

        [DisplayName("Role Name")]
        public string RoleName { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}