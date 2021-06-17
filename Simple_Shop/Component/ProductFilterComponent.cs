using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Simple_Shop.Data.Repositories;
using Simple_Shop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Component
{
    public class ProductFilterComponent : ViewComponent
    {
        private readonly IFilterRepository _filterRepository;

        public ProductFilterComponent(IFilterRepository filterRepository)
        {
            _filterRepository = filterRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ProductFilterViewModel model = new();
            
            return View("/Views/Components/FilteredProduct.cshtml" , model);
        }
    }
}
