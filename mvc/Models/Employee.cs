using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc.Models
{
    public class Employee
    {
        public List<Employee> DE { get; set; }
        public List<Employee> DM { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Key]
        public int id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string technology { get; set; }
        public DateTime optstartdate { get; set; }
        public string instructor { get; set; }
        public bool isconsultant { get; set; }
    }
}