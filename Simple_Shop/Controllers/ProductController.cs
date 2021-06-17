using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simple_Shop.Data;
using Simple_Shop.Models;
using Simple_Shop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Controllers
{
    public class ProductController : Controller
    {
        private DataBaseContext _context;

        public ProductController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var product = _context.Products.Include(p => p.PicPath).ToList();

            return View(product);
        }



        // GET: ProductController/Create
        public ActionResult Create()
        {
            InsertProductVM insert = new()
            {
                Categories = _context.Categories.ToList()
            };
            return View(insert);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InsertProductVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Pic1 == null || model.Pic2 == null || model.Pic3 == null || model.Pic4 == null || model.Pic5 == null || model.Pic6 == null)
            {

                ModelState.AddModelError("Pic1", "Please Upload 6 Picture for Product");
            }
            List<IFormFile> temp = new List<IFormFile>();
            temp.Add(model.Pic1);
            temp.Add(model.Pic2);
            temp.Add(model.Pic3);
            temp.Add(model.Pic4);
            temp.Add(model.Pic5);
            temp.Add(model.Pic6);
            var upload = UploadFile(temp);
            PicPath pic = new PicPath()
            {

                Pic1Path = upload[0],
                Pic2Path = upload[1],
                Pic3Path = upload[2],
                Pic4Path = upload[3],
                Pic5Path = upload[4],
                Pic6Path = upload[5],


            };
            _context.PicPaths.Add(pic);
            _context.SaveChanges();

            Product product = new Product()
            {

                PicPath_Id = pic.Id,
                PicPath = pic,
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                QuantityInStock = model.QuantityInStock,
                DiscountPrice = model.DiscountPrice,
                SoldCount = 0,
                CreatedDate=DateTime.Now,
                Likes=0
                

            };
            _context.Products.Add(product);
            _context.SaveChanges();
            if (model.SelectedGroup.Any()&& model.SelectedGroup.Count() >0)
            {
                foreach (int i in model.SelectedGroup)
                {
                    _context.CategoryToProducts.Add(new CategoryToProduct()
                    {
                        CategoryId = i,
                        ProductId=product.Id

                    });
                }
                _context.SaveChanges();
            }
            
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {

            var product = _context.Products.Find(id);
            var categories = _context.Categories.ToList();
            var groups = _context.CategoryToProducts.Where(c => c.ProductId == id).Select(s => s.CategoryId).ToList();
            UpdateProductVM model = new()
            {
                Id = product.Id,
                Description = product.Description,
                DiscountPrice = product.DiscountPrice,
                Title = product.Title,
                QuantityInStock = product.QuantityInStock,
                Price = product.Price,

                PicPath_Id = product.PicPath_Id,
                Categories = categories,
                SelectedGroup = groups

              

            };

            

            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateProductVM model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model.Pic1 == null || model.Pic2 == null || model.Pic3 == null || model.Pic4 == null || model.Pic5 == null || model.Pic6 == null)
            {

                ModelState.AddModelError("Pic1", "Please Upload 6 Picture for Product");
            }

            DeleteFile(model.PicPath_Id);
            List<IFormFile> temp = new List<IFormFile>();
            temp.Add(model.Pic1);
            temp.Add(model.Pic2);
            temp.Add(model.Pic3);
            temp.Add(model.Pic4);
            temp.Add(model.Pic5);
            temp.Add(model.Pic6);
            var upload = UploadFile(temp);

            var pic = _context.PicPaths.Find(model.PicPath_Id);
            pic.Pic1Path = upload[0];
            pic.Pic2Path = upload[1];
            pic.Pic3Path = upload[2];
            pic.Pic4Path = upload[3];
            pic.Pic5Path = upload[4];
            pic.Pic6Path = upload[5];
            _context.PicPaths.Update(pic);
            _context.SaveChanges();
            var product = _context.Products.Find(model.Id);

            product.Description = model.Description;
            product.DiscountPrice = model.DiscountPrice;
            product.Title = model.Title;
            product.QuantityInStock = model.QuantityInStock;
            product.Price = model.Price;
            product.SoldCount = 0;
            product.PicPath_Id = pic.Id;




            _context.Products.Update(product);
            _context.SaveChanges();
            _context.CategoryToProducts.Where(c => c.ProductId == product.Id).ToList().ForEach(g => _context.CategoryToProducts.Remove(g));

            if (model.SelectedGroup.Any() && model.SelectedGroup.Count() > 0)
            {
                foreach (int i in model.SelectedGroup)
                {
                    _context.CategoryToProducts.Add(new CategoryToProduct()
                    {
                        CategoryId = i,
                        ProductId = product.Id

                    });
                }
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }




        public ActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            DeleteFile(product.PicPath_Id);
            _context.Remove(product.PicPath);
            _context.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public List<string> UploadFile(List<IFormFile> temp)
        {

            string fileName = null;



            List<string> st = new List<string>();

            foreach (var item in temp)
            {
                if (item != null)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(item.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                           "wwwroot",
                           "images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    st.Add(fileName);
                }
            }

            return st;
        }
        public void DeleteFile(int id)
        {
            PicPath pic = _context.PicPaths.Find(id);
            List<string> temp = new List<string>();
            temp.Add(pic.Pic1Path);
            temp.Add(pic.Pic2Path);
            temp.Add(pic.Pic3Path);
            temp.Add(pic.Pic4Path);
            temp.Add(pic.Pic5Path);
            temp.Add(pic.Pic6Path);

            foreach (var item in temp)
            {

                var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images", item);
                if (System.IO.File.Exists(filePath))
                {

                    System.IO.File.Delete(filePath);
                }
            }

        }

       
    }
}
