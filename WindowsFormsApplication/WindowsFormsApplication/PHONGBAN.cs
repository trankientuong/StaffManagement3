//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class PHONGBAN
    {
        public PHONGBAN()
        {
            this.NHANVIENs = new HashSet<NHANVIEN>();
        }
    
        public int Id { get; set; }
        public string room { get; set; }
        public string position { get; set; }
    
        public virtual ICollection<NHANVIEN> NHANVIENs { get; set; }
        public virtual SalaryStaff SalaryStaff { get; set; }
    }
}
