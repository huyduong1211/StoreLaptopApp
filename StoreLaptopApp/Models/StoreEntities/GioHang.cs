using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    public class GioHang
    {
       public long ProductId { get; set; }
        public int Quantity { get; set; }
    }
   
}