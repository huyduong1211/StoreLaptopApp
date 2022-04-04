using DoAnChuyenNganhConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.Bus
{
    public class CommentBus
    {
        public static void ThemComment(int masp, string Content, string IdAccount, string NameAccount)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            Comment comment = new Comment();
            comment.ProductId = masp;
            comment.Content = Content;
            comment.IdAccount = IdAccount;
            comment.NameAccount = NameAccount;
            db.Execute("INSERT INTO [dbo].[Comments] ([Content],[ProductId],[IdAccount],[NameAccount])VALUES(@0,@1,@2,@3)", Content, masp, IdAccount, NameAccount);
        }
        public static IEnumerable<Comment> DanhSach(int masp)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Comment>("select * from Comments where ProductId = @0 and Note=1", masp);
        }
        //public static IEnumerable<Comment> DanhSach(int masp)
        //{
        //    var db = new DoAnChuyenNganhConnectionDB();
        //    return db.Query<Comment>("select * from Comments where Note = 1", masp);
        //}
        //admin
        public static IEnumerable<Comment> DanhSachAdmin()
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.Query<Comment>("select * from Comments ");
        }
        public static Comment ChiTiet(int id)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            return db.SingleOrDefault<Comment>("select * from Comments where Id = '" + id + "'");
        }
        public static void UpdateAdmin(int id, Comment comment)
        {
            var db = new DoAnChuyenNganhConnectionDB();
            db.Update(comment, id);
        }



    }
}