using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.DAL.Repositories
{
    public class ManufacturerRepository : IRepository<Manufacturer>
    {
        private readonly ShopAdo _context = new ShopAdo();

        public void AddOrUpdate(Manufacturer obj)
        {
            _context.Manufacturer.AddOrUpdate(obj);
            _context.SaveChanges();
        }

        public void Delete(Manufacturer obj)
        {
            _context.Manufacturer.Remove(obj);
            _context.SaveChanges();
        }

        public Manufacturer Get(int id)
        {
            return _context.Manufacturer.FirstOrDefault(x => x.ManufacturerId == id);
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            return _context.Manufacturer;
        }

        public IEnumerable<Manufacturer> FindBy(Expression<Func<Good, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        ~ManufacturerRepository()
        {
            _context.Dispose();
        }
    }
}
