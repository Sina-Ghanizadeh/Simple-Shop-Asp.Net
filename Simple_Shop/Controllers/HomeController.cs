using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_Shop.Data;
using Simple_Shop.Data.Repositories;
using Simple_Shop.Models;
using Simple_Shop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Controllers
{
    public class HomeController : Controller
    {
        private DataBaseContext _context;
        private IFilterRepository _filterRepository;

        public HomeController(DataBaseContext context, IFilterRepository filterRepository)
        {
            _context = context;
            _filterRepository = filterRepository;
        }

        public IActionResult Index()
        {
            var product = _context.Products.Include(p => p.PicPath).ToList();

            return View(product);
        }
        [Route("Home/Detail/{id}")]
        public IActionResult Detail(int id)
        {
            var product = _context.Products.Include(p => p.PicPath).SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            DetailsViewModel model = new()
            {
                Product = product
            };
            return View(model);
        }
        public IActionResult AddToCart(int id)
        {

            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product != null)
            {

                if (product.DiscountPrice != 0)
                {
                    AddProductToCart(product, product.DiscountPrice);
                }
                else
                {
                    AddProductToCart(product, product.Price);
                }
               

                _context.SaveChanges();

            }


            return RedirectToAction(nameof(ShowCart));
        }

        public void AddProductToCart(Product product, decimal price)
        {
            var order = _context.Orders.FirstOrDefault(o => !o.IsFinaly);

            if (order != null)
            {
                var orderDetail = _context.OrderDetails
                    .FirstOrDefault(d => d.OrderId == order.OrderId && d.ProductId == product.Id);
                if (orderDetail != null)
                {

                    orderDetail.Count += 1;
                }
                else
                {
                    _context.OrderDetails.Add(new OrderDetail()
                    {

                        OrderId = order.OrderId,
                        ProductId = product.Id,
                        Price = price,
                        Count = 1


                    });
                }
            }
            else
            {
                order = new Order
                {

                    IsFinaly = false,
                    CreateDate = DateTime.Now

                };
                _context.Orders.Add(order);
                _context.SaveChanges();
                _context.OrderDetails.Add(new OrderDetail()
                {

                    OrderId = order.OrderId,
                    ProductId = product.Id,
                    Price = price,
                    Count = 1


                });
            }

        }

        public IActionResult ShowCart()
        {


            var order = _context.Orders.Where(o => !o.IsFinaly)
                .Include(o => o.OrderDetail)
                .ThenInclude(c => c.Product).ThenInclude(u => u.PicPath).FirstOrDefault();

            return View(order);
        }

        public IActionResult RemoveItem(int detailId)
        {

            var orderDetail = _context.OrderDetails.Find(detailId);
            _context.Remove(orderDetail);
            _context.SaveChanges();


            return RedirectToAction("ShowCart");
        }
        [Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id, string name)
        {
            ViewData["GroupName"] = name;
            var products = _context.CategoryToProducts
                .Where(c => c.CategoryId == id)
                .Include(c => c.Product).ThenInclude(p=>p.PicPath)
                .Select(c => c.Product)
                .ToList();
            return View(products);
        }
        public IActionResult Like(int id)
        {


            var product = _context.Products.Find(id);
            product.Likes += 1;
            _context.Update(product);
            _context.SaveChanges();

            return RedirectToAction("Detail",product);

        }

        
        public IActionResult Filter(ProductFilterViewModel model)
        {
            var result = _filterRepository.GetProducts(model).Include(p=>p.PicPath);
            return View(result);
        }

    }
}
