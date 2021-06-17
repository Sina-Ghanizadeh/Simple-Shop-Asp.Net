using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Models.ViewModels
{
    public class ProductFilterViewModel
    {
       
        
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        public bool SoldCount { get; set; }
        public bool CreatedDate { get; set; }
        public bool MaxPrice { get; set; }
        public bool MinPrice { get; set; }
        public bool Likes { get; set; }

       

        public string Name { get; set; }


    }
}
