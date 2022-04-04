using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Show> Shows { get; set; }
    }
}