using Ninject;
using ShopAdo.DAL;
using ShopAdo.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Helpers
{
    public class ShopAdoDP : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public ShopAdoDP()
        {
            _kernel = new StandardKernel();

            _kernel.Bind<IRepository<Good>>().To<GoodRepository>();
            _kernel.Bind<IRepository<Category>>().To<CategoryRepository>();
            _kernel.Bind<IRepository<Manufacturer>>().To<ManufacturerRepository>();
            _kernel.Bind<IRepository<Photo>>().To<PhotoRepository>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}