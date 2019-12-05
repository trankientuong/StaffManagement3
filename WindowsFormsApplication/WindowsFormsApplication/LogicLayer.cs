using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication
{
    public class LogicLayer
    {
        public NHANVIEN[] GetNhanVien()
        {
            var db = new QLNV1Entities();
            return db.NHANVIENs.ToArray();
        }
        public void CreateStaff(string name,string gender,DateTime dateofbirth,string phonenumber,string address,int room)
        {
            var db = new QLNV1Entities();
            var newStaff = new NHANVIEN();
            newStaff.name = name;
            newStaff.gender = gender;
            newStaff.dateofbirth = dateofbirth;
            newStaff.phonenumber = phonenumber;
            newStaff.address = address;
            newStaff.room = room;
            db.NHANVIENs.Add(newStaff);
            db.SaveChanges();
        }
        public PHONGBAN[] GetRoom()
        {
            var db = new QLNV1Entities();
            return db.PHONGBANs.ToArray();
        }

        public void UpdateStaff(int id, string name, string gender, DateTime dateofbirth, string phonenumber, string address, int room)
        {
            var db = new QLNV1Entities();
            var oldStaff = db.NHANVIENs.Find(id);
            oldStaff.name = name;
            oldStaff.gender = gender;
            oldStaff.dateofbirth = dateofbirth;
            oldStaff.phonenumber = phonenumber;
            oldStaff.address = address;
            oldStaff.room = room;
            db.Entry(oldStaff).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteStaff(int id)
        {
            var db = new QLNV1Entities();
            var staff = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(staff);
            db.SaveChanges();
        }
        public NHANVIEN Get1NhanVien(int id)
        {
            var db = new QLNV1Entities();
            var staff = db.NHANVIENs.Find(id);
            return staff;
        }
    }
}
