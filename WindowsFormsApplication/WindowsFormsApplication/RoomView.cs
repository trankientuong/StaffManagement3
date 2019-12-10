using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication
{
    class RoomView
    {
        public int Id { get; set; }
        public string room { get; set; }
        public string position { get; set; }
        public int NHANVIEN { get; set; }
        public RoomView(PHONGBAN room)
        {
            this.Id = room.Id;
            this.room = room.room;
            this.position = room.position;
            this.NHANVIEN = room.NHANVIENs.Count;
        }
    }
}
