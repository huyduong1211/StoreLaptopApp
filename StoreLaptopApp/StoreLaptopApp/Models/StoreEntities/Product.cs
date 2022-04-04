using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PublicYear { get; set; }
        public double Price { get; set; }
        public string Cover { get; set; }

        public ICollection<Show> Shows { get; set; }
    }
    
}