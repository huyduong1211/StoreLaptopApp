using DoAnChuyenNganhConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.Bus
{
    public class PhukienBus
    {
        public static IEnumerable<Producer> DanhSach()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Producer>("select * from Producers where Status = 1 ");
        }
        public static IEnumerable<Product> ChiTiet(int id)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products where IdProducer = '" + id + "' ");
        }
    }
}