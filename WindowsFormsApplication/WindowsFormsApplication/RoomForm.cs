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
    public partial class RoomForm : Form
    {
        private LogicLayer Business;
        public RoomForm()
        {
            InitializeComponent();
            this.Business = new LogicLayer();
            this.Load += RoomForm_Load;
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            this.loadAllRoom();
        }
        private void loadAllRoom()
        {
            //this.grdRoom.DataSource = this.Business.GetRoom();
            var room = this.Business.GetRoom();
            var roomviews = new RoomView[room.Length];
            for (int i = 0; i < roomviews.Length; i++)
            {
                roomviews[i] = new RoomView(room[i]);
            }
            this.grdRoom.DataSource = roomviews;
        }
    }
}
