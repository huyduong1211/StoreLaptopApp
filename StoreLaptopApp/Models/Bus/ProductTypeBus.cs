using DoAnChuyenNganhConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.Bus
{
    public class ProductTypeBus
    {
        public static IEnumerable<ProductType> DanhSach()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<ProductType>("select * from ProductTypes where Status = 0 ");
        }
        public static IEnumerable<Product> ChiTiet(int id)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Product>("select * from Products where IdProductType = '" + id + "' ");
        }
        //admin
        public static IEnumerable<ProductType> DanhSachAdmin()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<ProductType>("select * from ProductTypes  ");
        }
        public static void ThemLoai(ProductType productType)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            db.Insert(productType);
        }
        public static ProductType ChiTietAdmin(int id)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.SingleOrDefault<ProductType>("select * from ProductTypes where IdProductType = '" + id + "' ");
        }
        public static void UpdateLoai(int id, ProductType productType)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            db.Update(productType, id);
        }
        public static void DeleteLoai(ProductType productType)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            db.Delete(productType);
        }
    }
}