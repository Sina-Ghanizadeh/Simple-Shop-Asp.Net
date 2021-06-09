using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Models.ViewModels
{
    public class UpdateProductVM
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
        public int PicPath_Id { get; set; }
        public IFormFile Pic1 { get; set; }
        public IFormFile Pic2 { get; set; }
        public IFormFile Pic3 { get; set; }
        public IFormFile Pic4 { get; set; }
        public IFormFile Pic5 { get; set; }
        public IFormFile Pic6 { get; set; }
    }
}
