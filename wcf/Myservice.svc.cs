using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using wcf;

namespace wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Myservice" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Myservice.svc or Myservice.svc.cs at the Solution Explorer and start debugging.
    public class Myservice : IMyservice
    {
        public void DoWork()
        {
        }

        public List<Marketing> GetAllMarketers()
        {
            List<Marketing> Marlst = new List<Marketing>();
            applabsEntities appDb = new applabsEntities();
            var lstemp = from k in appDb.Marketings select k;
            foreach (var item in lstemp)
            {
                Marketing Emp = new Marketing();

                Emp.Eid = item.Eid;
                Emp.optstatus = item.optstatus;

                Emp.optstartdate = item.optstartdate;

                Emp.mid = item.mid;
                Marlst.Add(Emp);

            }
            return Marlst;
        }


        public List<Employer> GetAllEmployers()
        {
            List<Employer> Emplst = new List<Employer>();
            applabsEntities appDb = new applabsEntities();
            var lstemp = from k in appDb.Employers select k;
            foreach (var item in lstemp)
            {
                Employer Emp = new Employer();

                Emp.id = item.id;
                Emp.optstatus = item.optstatus;
                Emp.Fname = item.Fname;
                Emp.Lname = item.Lname;
                Emp.technology = item.technology;
                Emp.optstartdate = item.optstartdate;
                Emp.instructor = item.instructor;
                Emp.isconsultant = item.isconsultant;
                Emplst.Add(Emp);

            }
            return Emplst;
        }
        public Employer GetAllemployerByid(int id)
        {

            applabsEntities appDB = new applabsEntities();
            var lstEmp = from k in appDB.Employers where k.id == id select k;
            Employer Emp = new Employer();
            foreach (var item in lstEmp)
            {

                Emp.id = item.id;
                Emp.optstatus = item.optstatus;
                Emp.Fname = item.Fname;
                Emp.Lname = item.Lname;
                Emp.technology = item.technology;
                Emp.optstartdate = item.optstartdate;
                Emp.instructor = item.instructor;
            }

            return Emp;
        }
        public Marketing GetAllMarketerByid(int Eid)
        {

            applabsEntities appDB = new applabsEntities();
            var lstEmp = from k in appDB.Marketings where k.Eid == Eid select k;
            Marketing Emp = new Marketing();
            foreach (var item in lstEmp)
            {

                Emp.Eid = item.Eid;
                Emp.optstatus = item.optstatus;
                Emp.mid = item.mid;
                Emp.optstartdate = item.optstartdate;

            }

            return Emp;
        }
        public int DeleteMarkByEid(int mid)
        {
            applabsEntities appDb = new applabsEntities();
            Marketing Markdtl = new Marketing();
            Markdtl.mid = mid;
            if (Markdtl.mid > 0)
            {
                appDb.Entry(Markdtl).State = EntityState.Deleted;
            }
            else
            {
                appDb.Entry(Markdtl).State = EntityState.Added;
            }
            int val = appDb.SaveChanges();
            return val;
        }

        public int DeleteEmpByid(int id)
        {

            applabsEntities appDb = new applabsEntities();
            Employer Empdtl = new Employer();
            Empdtl.id = id;
            appDb.Entry(Empdtl).State = EntityState.Deleted;

            int val = appDb.SaveChanges();
            return val;
        }

        public int AddEmp(int id, string Fname, string Lname, string instructor, DateTime optstartdate, string technology, bool isconsultant)
        {
            applabsEntities appDb = new applabsEntities();
            Employer Empdtl = new Employer();
            Empdtl.id = id;
            Empdtl.Fname = Fname;
            Empdtl.Lname = Lname;
            Empdtl.technology = technology;
            Empdtl.optstartdate = optstartdate;
            Empdtl.instructor = instructor;
            Empdtl.isconsultant = isconsultant;
            appDb.Entry(Empdtl).State = EntityState.Added;
            int val = appDb.SaveChanges();
            return val;



        }
        public int AddMark(int Eid, DateTime optstartdate, int mid, string optstatus)
        {


            applabsEntities appDb = new applabsEntities();
            Marketing Empdtl = new Marketing();
            //Employer Emp = new Employer();
            Empdtl.Eid = Eid;
            Empdtl.mid = mid;
            Empdtl.optstartdate = optstartdate;
            Empdtl.optstatus = optstatus;
            appDb.Entry(Empdtl).State = EntityState.Added;
            int val = appDb.SaveChanges();
            return val;



        }
        public int UpdateMark(int Eid, DateTime optstartdate, int mid, string optstatus)
        {
            applabsEntities appDb = new applabsEntities();
            Marketing Empdtl = new Marketing();
            Empdtl.Eid = Eid;
            Empdtl.mid = mid;
            Empdtl.optstatus = optstatus;
            Empdtl.optstartdate = optstartdate;
            appDb.Entry(Empdtl).State = EntityState.Modified;
            int Retval = appDb.SaveChanges();
            return Retval;

        }
        public int UpdateEmp(int id, string Fname, string Lname, string instructor, DateTime optstartdate, string technology, bool isconsultant)
        {
            applabsEntities appDb = new applabsEntities();
            Employer Empdtl = new Employer();
            Empdtl.id = id;
            Empdtl.Fname = Fname;
            Empdtl.Lname = Lname;
            Empdtl.technology = technology;
            Empdtl.optstartdate = optstartdate;
            Empdtl.instructor = instructor;
            appDb.Entry(Empdtl).State = EntityState.Modified;
            int Retval = appDb.SaveChanges();
            return Retval;

        }
    }



}
