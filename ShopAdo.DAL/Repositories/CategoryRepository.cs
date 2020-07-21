using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly ShopAdo _context = new ShopAdo();

        public void AddOrUpdate(Category obj)
        {
            _context.Category.AddOrUpdate(obj);
            _context.SaveChanges();
        }

        public void Delete(Category obj)
        {
            _context.Category.Remove(obj);
            _context.SaveChanges();
        }

        public Category Get(int id)
        {
            return _context.Category.FirstOrDefault(x => x.CategoryId == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category;
        }
        
        public IEnumerable<Category> FindBy(Expression<Func<Good, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        ~CategoryRepository()
        {
            _context.Dispose();
        }
    }
}
