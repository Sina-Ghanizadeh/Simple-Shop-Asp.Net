using Simple_Shop.Models;
using Simple_Shop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Shop.Data.Repositories
{
    public interface IGroupRepository
    {

        IEnumerable<Category> GetAllCategories();

        IEnumerable<ShowGroupViewModel> GetGroupForShow();
    }
    public class GroupRepository : IGroupRepository
    {
        private readonly DataBaseContext _context;

        public GroupRepository(DataBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;

        }

        public IEnumerable<ShowGroupViewModel> GetGroupForShow()
        {
            return _context.Categories
                .Select(c => new ShowGroupViewModel()
                {

                    Id = c.Id,
                    Name = c.Name,
                    ProductCount = _context.CategoryToProducts.Count(g => g.CategoryId == c.Id)
                }).ToList();

        }
    }
}
