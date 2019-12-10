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
    public partial class CreateStaffForm : Form
    {
        private LogicLayer Business;
        public CreateStaffForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.btnSave.Click += btnSave_Click;
            this.Load += CreateForm_Load;
        }

        void CreateForm_Load(object sender, EventArgs e)
        {
            this.cboRoom.DataSource = this.Business.GetRoom();
            this.cboRoom.DisplayMember = "Room";
            this.cboRoom.ValueMember = "id";
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            string gender = "";
            var name = this.txtName.Text;
            if (rbMale.Checked)
            {
                 gender = this.rbMale.Text;
            }else
            {
                 gender = this.rbFemale.Text;
            }
            var dateofbirth = this.dtpBirthday.Value;
            var phonenumber = this.txtPhone.Text;
            var address = this.txtAddress.Text;
            var room = (int)this.cboRoom.SelectedValue;
            this.Business.CreateStaff(name, gender, dateofbirth, phonenumber, address, room);
            MessageBox.Show("Create successfully");
            this.Close();
        }
    }
}
