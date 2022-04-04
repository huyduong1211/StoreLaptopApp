using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreLaptopApp.Models.StoreEntities
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int BirthDate { get; set; }
        public string Address { get; set; }
    }
}