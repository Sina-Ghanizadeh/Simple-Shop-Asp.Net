using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime  EditDate{ get; set; }
        public int UserId { get; set; }

       

        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
