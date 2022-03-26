using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ADONETEntityFramework.SQL_MODELS
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }

        public string ContactName { get; set; }

        public string Address { get; set; }

        public string MobileNumber { get; set; }

        public string Country { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
