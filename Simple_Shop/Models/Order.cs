using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsFinaly { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }
    }
}
