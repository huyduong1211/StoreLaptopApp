using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string IdAccount { get; set; }
        public string NameAccount { get; set; }
        public string Content { get; set; }
        public int Note { get; set; }
        public DateTime Day { get; set; }


        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}