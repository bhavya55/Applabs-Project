using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using wcf;
using System.Web.Mvc;


namespace mvc.Models
{
    public class Marketer
    {
        [Key]
        public int Eid { get; set; }
        public int mid { get; set; }
        public string optstatus { get; set; }
        public DateTime optstartdate { get; set; }

        public List<Employer> DE { get; set; }
        public List<Employer> DM { get; set; }


        public virtual Employer Employer { get; set; }

        internal class Find : Marketer
        {
            private new int? mid;

            public Find(int? mid)
            {
                this.mid = mid;
            }
        }
    }
}