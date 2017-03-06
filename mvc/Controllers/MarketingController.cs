using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wcf;

namespace mvc.Controllers
{

    public class MarketingController : Controller
    {

        ServiceReference1.MyserviceClient sc = new ServiceReference1.MyserviceClient();

        public ActionResult Index()
        {
            List<Marketer> lstRecord = new List<Marketer>();
            var lst = sc.GetAllMarketers();

            foreach (var item in lst)
            {
                Marketer Emp = new Marketer();
                Emp.Eid = item.Eid;
                Emp.mid = item.mid;
                Emp.optstatus = item.optstatus;
                Emp.optstartdate = item.optstartdate;
                lstRecord.Add(Emp);
            }
            return View(lstRecord);
        }

        // GET: Marketing/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Marketing/Create
        public ActionResult Create()
        {
            applabsEntities db = new applabsEntities();
            Marketer mark = new Marketer();
            mark.DE = db.Employers.Where(x => x.isconsultant == false).ToList();
            mark.DM = db.Employers.Where(x => x.isconsultant == true).ToList();

            return View(mark);
        }
       [ HttpPost]
        public ActionResult Create(Marketer mdl)
        {
            Marketer Emp = new Marketer();
            Emp.Eid = mdl.Eid;
            Emp.optstartdate = mdl.optstartdate;
            Emp.mid = mdl.mid;
            Emp.optstatus = mdl.optstatus;
            sc.AddMark(Emp.Eid, Emp.optstartdate,Emp.mid, Emp.optstatus);
            return RedirectToAction("Index", "Marketing");

        }
     

        // GET: Marketing/Edit/5
        public ActionResult Edit(int Eid)
        {
            applabsEntities db = new applabsEntities();
            Marketer mark = new Marketer();
            mark.DE = db.Employers.Where(x => x.isconsultant == false).ToList();
            mark.DM = db.Employers.Where(x => x.isconsultant == true).ToList();
            return View(mark);
        }

        // POST: Marketing/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ServiceReference1.MyserviceClient sc = new ServiceReference1.MyserviceClient();
                int mid = Convert.ToInt32(collection["mid"]);
                int Eid = Convert.ToInt32(collection["Eid"]);
                DateTime optstartdate = Convert.ToDateTime(collection["optstartdate"]);
                string optstatus = Convert.ToString(collection["optstatus"]);
                int Retval = sc.UpdateMark(Eid, optstartdate, mid, optstatus);
                if (Retval > 0)
                {
                    return RedirectToAction("Index", "Marketing");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: Marketing/Delete/5
        // [HttpPost]
        public ActionResult Delete(int mid)
        {
            int val = sc.DeleteMarkByEid(mid);  

            if (val > 0)
            {
                return RedirectToAction("Index", "Marketing");
            }

            return View();
        }
    }
}
