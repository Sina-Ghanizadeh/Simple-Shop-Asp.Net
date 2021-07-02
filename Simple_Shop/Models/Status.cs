using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        [Required]
        public string Name { get; set; }
       
        public List<Order> Orders { get; set; }
        

    }
}
