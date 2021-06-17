using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Simple_Shop.Models;
using Simple_Shop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data.Repositories
{
    public interface IFilterRepository
    {

        IQueryable<Product> GetProducts(ProductFilterViewModel filter);
    }
        public class FilterRepository : IFilterRepository
        {
            private DataBaseContext _context;

            public FilterRepository(DataBaseContext context)
            {
                _context = context;
            }


            public IQueryable<Product> GetProducts(ProductFilterViewModel filter)
            {

                var result = _context.Products.AsQueryable();
                if (filter != null)
                {

                   
                    if (!string.IsNullOrEmpty(filter.Name))
                        result = result.Where(x => x.Title.Contains(filter.Name));
                    if (filter.PriceFrom.HasValue)
                        result = result.Where(x => x.Price >= filter.PriceFrom);
                    if (filter.PriceTo.HasValue)
                        result = result.Where(x => x.Price <= filter.PriceTo);
                    if (filter.SoldCount)
                        result = result.OrderByDescending(p => p.SoldCount);
                    if (filter.CreatedDate)
                        result = result.OrderByDescending(p => p.CreatedDate);
                    if (filter.MaxPrice)
                        result = result.OrderByDescending(p => p.Price);
                    if (filter.MinPrice)
                        result = result.OrderBy(p => p.Price);
                    if (filter.Likes)
                        result = result.OrderBy(p => p.Likes);






                }
                return result;
            }


        }

    }
