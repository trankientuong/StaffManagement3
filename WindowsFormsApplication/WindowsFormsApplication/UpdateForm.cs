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
    public partial class UpdateForm : Form
    {
        private LogicLayer Business;
        private int StaffId;
        public UpdateForm(int id)
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.StaffId = id;
            this.Load += UpdateForm_Load;
            
        }

        void UpdateForm_Load(object sender, EventArgs e)
        {
            this.cboRoom.DataSource = this.Business.GetRoom();
            this.cboRoom.DisplayMember = "Name";
            this.cboRoom.ValueMember = "Id";
            //var staff = this.Business.g
        }
    }
}
