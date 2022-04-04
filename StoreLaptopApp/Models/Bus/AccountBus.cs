using DoAnChuyenNganhConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.Bus
{
    public class AccountBus
    {
        public static IEnumerable<AspNetUser> DanhSachAdmin()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<AspNetUser>("select * from AspNetUsers ");
        }
        public static AspNetUser ChiTietAdmin(string id)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.SingleOrDefault<AspNetUser>("select * from AspNetUsers where Id = '" + id + "' ");
        }
        public static void Update(string id, AspNetUser asp)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            db.Update(asp, id);
        }
        public static void Delete(AspNetUser asp)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            db.Delete(asp);
        }
    }
}