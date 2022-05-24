using SSquaredPersonnel.Models;
using System.Collections.Generic;

namespace SSquaredPersonnel.DAL
{
    public class PersonnelData : System.Data.Entity. DropCreateDatabaseIfModelChanges<PersonnelContext>
    {
        protected override void Seed(PersonnelContext context)
        {
            var roles = new List<Role>
            {
            new Role{RoleID=1,RoleName="Director"},
            new Role{RoleID=2,RoleName="IT"},
            new Role{RoleID=3,RoleName="Support"},
            new Role{RoleID=4,RoleName="Accounting"},
            new Role{RoleID=5,RoleName="Analyst"},
            new Role{RoleID=6,RoleName="Sales"}
            };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();

            var employees = new List<Employee>
            {
            new Employee{EmployeeID=1,Employee_ID="1",FirstName="Jeffrey",LastName="Wells"},
            new Employee{EmployeeID=2,Employee_ID="2",FirstName="Viktor",LastName="Atkins",ManagerID=1},
            new Employee{EmployeeID=3,Employee_ID="3",FirstName="Kelli",LastName="Hamilton",ManagerID=1},
            new Employee{EmployeeID=4,Employee_ID="4",FirstName="Adam",LastName="Braun",ManagerID=2},
            new Employee{EmployeeID=5,Employee_ID="5",FirstName="Brian",LastName="Cruz",ManagerID=2},
            new Employee{EmployeeID=6,Employee_ID="6",FirstName="Kristen",LastName="Floyd",ManagerID=2},
            new Employee{EmployeeID=7,Employee_ID="7",FirstName="Lois",LastName="Martinez",ManagerID=3},
            new Employee{EmployeeID=8,Employee_ID="8",FirstName="Michael",LastName="Lind",ManagerID=3},
            new Employee{EmployeeID=9,Employee_ID="9",FirstName="Eric",LastName="Bay",ManagerID=3},
            new Employee{EmployeeID=10,Employee_ID="10",FirstName="Brandon",LastName="Young",ManagerID=3}
            };
            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var jobs = new List<Job>
            {
            new Job{RoleID=1,EmployeeID=1},
            new Job{RoleID=1,EmployeeID=2},
            new Job{RoleID=1,EmployeeID=3},
            new Job{RoleID=2,EmployeeID=4},
            new Job{RoleID=2,EmployeeID=9},
            new Job{RoleID=3,EmployeeID=4},
            new Job{RoleID=3,EmployeeID=7},
            new Job{RoleID=4,EmployeeID=5},
            new Job{RoleID=4,EmployeeID=10},
            new Job{RoleID=5,EmployeeID=8},
            new Job{RoleID=5,EmployeeID=6},
            new Job{RoleID=6,EmployeeID=9},
            new Job{RoleID=6,EmployeeID=6}
            };
            jobs.ForEach(s => context.Jobs.Add(s));
            context.SaveChanges();
        }
    }
}
