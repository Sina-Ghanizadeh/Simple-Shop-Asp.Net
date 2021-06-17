using Microsoft.AspNetCore.Mvc;
using Simple_Shop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Simple_Shop.Component
{
    public class ProductGroupComponent :ViewComponent
    {

        private readonly IGroupRepository _groupRepository;

        public ProductGroupComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("/Views/Components/Product.cshtml", _groupRepository.GetGroupForShow());
        }
    }
}
