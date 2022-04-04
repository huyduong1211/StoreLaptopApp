using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    public class ProductType
    {
        [Key]
        public int IdProductType { get; set; }
        public string NameType { get; set; }
        public string Status { get; set; }
       
    }
}