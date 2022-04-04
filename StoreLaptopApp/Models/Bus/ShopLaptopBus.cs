using DoAnChuyenNganhConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.Bus
{
    public class ShopLaptopBus
    {
        public static IEnumerable<Product> DanhSach()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products where Quantity = 0 ");
        }

        public static Product ChiTiet(int a)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.SingleOrDefault<Product>("select * from Products where Id = @0", a);
        }
        public static IEnumerable<Product> FeatureProduct()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products where Note = 1");
        }
        public static IEnumerable<Product> LatestProduct()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products where Note = 5 ");
        }
        public static IEnumerable<Product> LatestProduct2()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products where Note = 6 ");
        }
        public static IEnumerable<Product> HeadPhone()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products where Note = 7 ");
        }
        public static IEnumerable<Product> HeadPhone2()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products where Note = 8 ");
        }
        public static IEnumerable<Product> KeyBoard()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products where Note = 9 ");
        }
        public static IEnumerable<Product> KeyBoard2()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products where Note = 10 ");
        }
        public static IEnumerable<Product> Category()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products where Note = 1");
        }
        public static IEnumerable<Product> Search(string key)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products where Name like '%" + key + "%'").ToList();
        }
        //public List<Product> Search(string key)
        //{
        //    var db = new DoAnChuyenNganhConnectionDB();
        //    return db.Query<Product>("select * from Products where like =  %" + key + "%").ToList();
        //}
        //admin
        public static IEnumerable<Product> DanhSachAdmin()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products ");
        }
        public static void Them(Product product)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            db.Insert(product);
        }
        public static Product ChiTietAdmin(int id)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.SingleOrDefault<Product>("select * from Products where Id = '" + id + "'" );
        }
        public static void Update(int id, Product product)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            db.Update(product, id);
        }
        public static void DeleteSp( Product product)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            db.Delete(product);
        }
    }
}