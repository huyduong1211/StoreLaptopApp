using DoAnChuyenNganhConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.Bus
{
    public class ProducerBus
    {
        public static IEnumerable<Producer> DanhSach()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Producer>("select * from Producers where Status = 0 ");
        }
        public static IEnumerable<Product> ChiTiet(int id)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products where IdProducer = '"+id+"' ");
        }
        //ADMIN
        public static IEnumerable<Producer> DanhSachAdmin()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Producer>("select * from Producers  ");
        }
        public static void ThemNsx(Producer producer)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            db.Insert(producer);
        }
        public static Producer ChiTietAdmin(int id)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.SingleOrDefault<Producer>("select * from Producers where IdProducer = '" + id + "' ");
        }
        public static void UpdateNsx(int id,Producer producer)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            db.Update(producer,id);
        }
        public static void DeleteNsx( Producer producer)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            db.Delete(producer);
        }
    }
}