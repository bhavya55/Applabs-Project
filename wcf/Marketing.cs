//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wcf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Marketing
    {
        public int Eid { get; set; }
        public string optstatus { get; set; }
        public int mid { get; set; }
        public System.DateTime optstartdate { get; set; }
    
        public virtual Employer Employer { get; set; }
    }
}
