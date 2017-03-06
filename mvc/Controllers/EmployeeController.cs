 using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wcf;

namespace mvc.Controllers
{
    public class EmployeeController : Controller
    {
        ServiceReference1.MyserviceClient sc = new ServiceReference1.MyserviceClient();


        public ActionResult Index()
        {

            List<Employee> lstRecord = new List<Employee>();
            var lst = sc.GetAllEmployers();


            foreach (var item in lst)
            {
                Employee Emp = new Employee();
                Emp.id = item.id;
                Emp.Fname = item.Fname;
                Emp.Lname = item.Lname;
                Emp.technology = item.technology;
                Emp.optstartdate = item.optstartdate;
                Emp.instructor = item.instructor;
                Emp.isconsultant = item.isconsultant;
                lstRecord.Add(Emp); ;
            }

            return View(lstRecord);
        }


        public ActionResult Create()
        {
            applabsEntities appDb = new applabsEntities();
            Employee emp = new Employee();
            return View(emp);

        }
        [HttpPost]
        public ActionResult Create(Employee mdl)
        {
            Employee Emp = new Employee();
            Emp.id = mdl.id;
            Emp.Fname = mdl.Fname;
            Emp.Lname = mdl.Lname;
            Emp.technology = mdl.technology;
            Emp.instructor = mdl.instructor;
            Emp.optstartdate = mdl.optstartdate;
            Emp.isconsultant = mdl.isconsultant;

            sc.AddEmp(Emp.id, Emp.Fname, Emp.Lname, Emp.instructor, Emp.optstartdate, Emp.technology, Emp.isconsultant);
            return RedirectToAction("Index", "Employee");

        }
        public ActionResult Delete(int id)
        {
            int retval = sc.DeleteEmpByid(id);

            if (retval > 0)
            {
                return RedirectToAction("Index", "Employee");
            }

            return View();
        }


        public ActionResult Edit(int id)
        {
            var lst = sc.GetAllemployerByid(id);
            Employee emp = new Employee();
            emp.id = lst.id;

            emp.Fname = lst.Fname;
            emp.Lname = lst.Lname;
            emp.technology = lst.technology;
            emp.instructor = lst.instructor;
            emp.optstartdate = lst.optstartdate;
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Models.Employee mdl)
        {
            Employee Emp = new Employee();
            Emp.id = mdl.id;

            Emp.Fname = mdl.Fname;
            Emp.Lname = mdl.Lname;
            Emp.technology = mdl.technology;
            Emp.instructor = mdl.instructor;
            Emp.optstartdate = mdl.optstartdate;
            Emp.isconsultant = mdl.isconsultant;
            int Retval = sc.UpdateEmp(Emp.id, Emp.Fname, Emp.Lname, Emp.instructor, Emp.optstartdate, Emp.technology, Emp.isconsultant);
            if (Retval > 0)
            {
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
    }
}
