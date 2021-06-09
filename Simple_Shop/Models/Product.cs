using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal DiscountPrice { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        public int SoldCount { get; set; }

        public PicPath PicPath { get; set; }
        public int PicPath_Id { get; set; }


    }
}
