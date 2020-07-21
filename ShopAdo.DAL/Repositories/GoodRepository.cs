using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.DAL.Repositories
{
    public class GoodRepository : IRepository<Good>
    {
        private readonly ShopAdo _context = new ShopAdo();

        public void AddOrUpdate(Good obj)
        {
            _context.Good.AddOrUpdate(obj);
            _context.SaveChanges();
        }

        public void Delete(Good obj)
        {
            _context.Good.Remove(obj);
            _context.SaveChanges();
        }

        public Good Get(int id)
        {
            return _context.Good.FirstOrDefault(x => x.GoodId == id);
        }

        public IEnumerable<Good> GetAll()
        {
            return _context.Good;
        }

        public IEnumerable<Good> FindBy(Expression<Func<Good, bool>> predicate)
        {
            return _context.Good.Where(predicate);
        }

        ~GoodRepository()
        {
            _context.Dispose();
        }
    }
}
