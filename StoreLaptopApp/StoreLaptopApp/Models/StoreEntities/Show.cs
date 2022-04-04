using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    public class Show
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public Store Store { get; set; }


        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

       
        


        public ICollection<Reservation> Reservations { get; set; }
    }
}