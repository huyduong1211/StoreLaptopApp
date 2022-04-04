using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    public class Producer
    {
        [Key]
        public int IdProducer { get; set; }
        public string NameProducer { get; set; }
        public string Status { get; set; }
    }
}