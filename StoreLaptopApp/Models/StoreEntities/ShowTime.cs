using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    public class ShowTime
    {
        public int Id { get; set; }
        public string Time { get; set; }

        public ICollection<Show> Shows { get; set; }
    }
}