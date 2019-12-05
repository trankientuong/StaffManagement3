using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class IndexForm : Form
    {
        private LogicLayer Business;
        public IndexForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += IndexForm_Load;
            this.btnCreate.Click += btnCreate_Click;
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new CreateForm();
            createForm.ShowDialog();
            this.LoadAllStaff();
        }

        void IndexForm_Load(object sender, EventArgs e)
        {
            this.LoadAllStaff();
        }
        private void LoadAllStaff()
        {
            //grdStaff.DataSource = this.Business.GetNhanVien();
            var staffs = this.Business.GetNhanVien();
            StaffView[] staffviews = new StaffView[staffs.Length];
            for (int i = 0; i < staffs.Length; i++)
            {
                staffviews[i] = new StaffView(staffs[i]);
            }
            grdStaff.DataSource = staffviews;
        }
    }
}
