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
    public partial class IndexStaffForm : Form
    {
        private LogicLayer Business;
        public IndexStaffForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += IndexForm_Load;
            this.btnCreate.Click += btnCreate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.grdStaff.DoubleClick += grdStaff_DoubleClick;
            this.btnShow.Click += btnShow_Click;
            this.txtFind.TextChanged += txtFind_TextChanged;
            this.txtFind.Leave += txtFind_Leave;
            this.txtFind.Enter += txtFind_Enter;
            this.btnSort.Click += btnSort_Click;
            this.btnFind.Click += btnFind_Click;
        }

        void btnFind_Click(object sender, EventArgs e)
        {
            var db = new QLNV1Entities();
            grdStaff.DataSource = db.NHANVIENs.Where(x => x.name.Contains(txtFind.Text)).ToList();
        }

        void btnSort_Click(object sender, EventArgs e)
        {
            var db = new QLNV1Entities();
            grdSalary.DataSource = db.SalaryStaffs.OrderBy(r => r.salary).ToList();
        }

        void txtFind_Enter(object sender, EventArgs e)
        {
            if (txtFind.Text == "Please enter name")
            {
                txtFind.Text = "";
                txtFind.ForeColor = Color.Gray;
            }
        }

        void txtFind_Leave(object sender, EventArgs e)
        {
            if (txtFind.Text == "")
            {
                txtFind.Text = "Please enter name";
                txtFind.ForeColor = Color.Gray;
            }
        }

        void txtFind_TextChanged(object sender, EventArgs e)
        {
            var db = new QLNV1Entities();
            grdStaff.DataSource = db.NHANVIENs.Where(x => x.name.Contains(txtFind.Text)).ToList();
        }

        void btnShow_Click(object sender, EventArgs e)
        {
            var roomForm = new RoomForm();
            roomForm.ShowDialog();
        }

        void grdStaff_DoubleClick(object sender, EventArgs e)
        {
            if (grdStaff.SelectedRows.Count == 1)
            {
                var staff = (StaffView)grdStaff.SelectedRows[0].DataBoundItem;
                var updateForm = new UpdateStaffForm(staff.Id);
                updateForm.ShowDialog();
                this.LoadAllStaff();
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdStaff.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Do you want to delete this ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var staff = (StaffView)grdStaff.SelectedRows[0].DataBoundItem;
                    this.Business.DeleteStaff(staff.Id);
                    MessageBox.Show("Delete successfully!");
                    this.LoadAllStaff();
                }
            }
        }

        void btnCreate_Click(object sender, EventArgs e)
        {
            var createForm = new CreateStaffForm();
            createForm.ShowDialog();
            this.LoadAllStaff();
        }

        void IndexForm_Load(object sender, EventArgs e)
        {
            this.LoadAllStaff();
            this.loadSalary();
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
            this.txtCount.Text = string.Format(staffs.Length.ToString());
        }
        private void loadSalary()
        {
            // grdSalary.DataSource = this.Business.GetSalary();
            var salary = this.Business.GetSalary();
            SalaryView[] salaryviews = new SalaryView[salary.Length];
            for(int i = 0; i < salaryviews.Length; i++)
            {
                salaryviews[i] = new SalaryView(salary[i]);
            }
            this.grdSalary.DataSource = salaryviews;
        }
    }
}
