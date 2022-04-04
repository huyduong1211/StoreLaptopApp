using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PublicYear { get; set; }
        public int Price { get; set; }
        public string Cover { get; set; }
        public string Cover1 { get; set; }
        public string Cover2 { get; set; }
        public string Cover3 { get; set; }
        public string Cover4 { get; set; }
        public int Quantity { get; set; }
        public string Like { get; set; }
        public string Note { get; set; }

        [ForeignKey("ProductType")]
        public int IdProductType { get; set; }
        public ProductType ProductType { get; set; }


        [ForeignKey("Producer")]
        public int IdProducer { get; set; }
        public Producer Producer { get; set; }

        public string ParsePrice()
        {
            return string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", this.Price);
        }
    }
    
    
}