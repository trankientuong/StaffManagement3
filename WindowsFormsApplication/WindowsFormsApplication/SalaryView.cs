using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication
{
    class SalaryView
    {
        public int Id { get; set; }
        public string salary { get; set; }



        public SalaryView(SalaryStaff salary)
        {
            this.Id = salary.Id;

            this.salary = string.Format("{0:##,##VNĐ}", salary.salary);


        }
    }
}
