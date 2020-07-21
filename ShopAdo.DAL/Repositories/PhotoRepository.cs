using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopAdo.DAL.Repositories
{
    public class PhotoRepository : IRepository<Photo>
    {
        private readonly ShopAdo _context = new ShopAdo();

        public void AddOrUpdate(Photo obj)
        {
            _context.Photo.AddOrUpdate(obj);
            _context.SaveChanges();
        }

        public void Delete(Photo obj)
        {
            _context.Photo.Remove(obj);
            _context.SaveChanges();
        }

        public Photo Get(int id)
        {
            return _context.Photo.FirstOrDefault(x => x.PhotoId == id);
        }

        public IEnumerable<Photo> GetAll()
        {
            return _context.Photo;
        }

        public IEnumerable<Photo> FindBy(Expression<Func<Good, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        ~PhotoRepository()
        {
            _context.Dispose();
        }
    }
}
