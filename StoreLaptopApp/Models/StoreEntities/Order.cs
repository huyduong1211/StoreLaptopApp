using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey("Employees")]
        public int EmployeesId { get; set; }
        public Employees Employees { get; set; }

        public bool Confirmed { get; set; }
        public bool Delivered { get; set; }
    }
}