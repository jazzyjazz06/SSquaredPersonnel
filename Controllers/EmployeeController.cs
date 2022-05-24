using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SSquaredPersonnel.DAL;
using SSquaredPersonnel.Models;

namespace SSquaredPersonnel.Controllers
{
    public class EmployeeController : Controller
    {
        private PersonnelContext db = new PersonnelContext();

        // GET: Employee
        public ActionResult Index()
        {
            GetEmployees();
            return View(db.Employees.ToList());
        }

        // GET: Employee/Manager/5
        public ActionResult Manager(int? id)
        {
            GetEmployees();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            List<Employee> employees = db.Employees.Where(e => e.ManagerID == id).ToList();
            if (employees == null)
            {
                return HttpNotFound();
            }

            ViewBag.Manager = id;
            return View("Index", employees);
        }
        

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            GetEmployees();
            GetRoles();
            return View();
        }

        public void GetEmployees()
        {
            List<SelectListItem> employees = db.Employees.Select(e => new SelectListItem { Text = e.LastName + ", " + e.FirstName, Value = "/Employee/Manager/"+e.EmployeeID.ToString() }).ToList();
            ViewBag.EmployeeList = employees;
        }

        public void GetRoles()
        { 
            List<SelectListItem> roles = db.Roles.Select(e => new SelectListItem { Text = e.RoleName , Value = e.RoleID.ToString() }).ToList();
            ViewBag.RoleList = roles;
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,ManagerID,Employee_ID,LastName,FirstName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }
        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,ManagerID,Employee_ID,LastName,FirstName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
