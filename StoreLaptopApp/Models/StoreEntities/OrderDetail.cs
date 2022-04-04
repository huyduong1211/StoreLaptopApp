using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}