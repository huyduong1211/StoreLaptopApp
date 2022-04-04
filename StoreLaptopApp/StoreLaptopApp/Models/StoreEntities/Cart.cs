using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    public class Cart
    {
        [Key]

        public long ProductId { get; set; }
        public int Quantity { get; set; }

        public Product product { get; set; }
    }
}
    
