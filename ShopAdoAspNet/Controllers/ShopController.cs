 using LinqKit;
using ShopAdo.DAL;
using ShopAdo.DAL.Repositories;
using ShopAdoAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Controllers
{
    public class ShopController : Controller
    {
        private readonly IRepository<Good> _goodRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Manufacturer> _manufacturerRepository;
        private readonly IRepository<Photo> _photoRepository;

        public ShopController(IRepository<Good> goodRepository, IRepository<Category> categoryRepository, IRepository<Manufacturer> manufacturerRepository, IRepository<Photo> photoRepository)
        {
            _goodRepository = goodRepository;
            _categoryRepository = categoryRepository;
            _manufacturerRepository = manufacturerRepository;
            _photoRepository = photoRepository;
        }

        public ActionResult Index()
        {
            var categories = new List<CheckBoxFor<Category>>();
            var manufacturers = new List<CheckBoxFor<Manufacturer>>();

            foreach (var item in _categoryRepository.GetAll())
                categories.Add(new CheckBoxFor<Category> { Item = item, IsChecked = false });

            foreach (var item in _manufacturerRepository.GetAll())
                manufacturers.Add(new CheckBoxFor<Manufacturer> { Item = item, IsChecked = false });

            var filter = new GoodFilter
            {
                Categories = categories,
                Manufacturers = manufacturers,
                PriceFrom = 0,
                PriceTo = (double)_goodRepository.GetAll().OrderByDescending(x => x.Price).FirstOrDefault().Price
            };

            return View(new DisplayGoodsViewModel { Filter = filter, Goods = new List<GoodViewModel>() });
        }

        [HttpPost]
        public ActionResult Index(GoodFilter filter)
        {
            var predicate = PredicateBuilder.New<Good>();
            predicate.And(x => (double)x.Price >= filter.PriceFrom);
            predicate.And(x => (double)x.Price <= filter.PriceTo);

            var predicateCategory = PredicateBuilder.New<Good>();
            foreach (var item in filter.Categories)
            {
                var predicateConcrete = PredicateBuilder.New<Good>();

                predicateConcrete.And(x => item.IsChecked);
                predicateConcrete.And(x => x.CategoryId == item.Item.CategoryId);

                predicateCategory.Extend(predicateConcrete);
            }

            var predicateManufacturer = PredicateBuilder.New<Good>();
            foreach (var item in filter.Manufacturers)
            {
                var predicateConcrete = PredicateBuilder.New<Good>();

                predicateConcrete.And(x => item.IsChecked);
                predicateConcrete.And(x => x.ManufacturerId == item.Item.ManufacturerId);

                predicateManufacturer.Extend(predicateConcrete);
            }

            predicate.Extend(predicateCategory, PredicateOperator.And);
            predicate.Extend(predicateManufacturer, PredicateOperator.And);

            var goods = new List<GoodViewModel>();
            foreach (var i in _goodRepository.FindBy(predicate))
            {
                goods.Add(new GoodViewModel
                {
                    GoodName = i.GoodName,
                    GoodCount = (int)i.GoodCount,
                    Price = i.Price,
                    Photos = _photoRepository.GetAll().Where(p => p.GoodId == i.GoodId).ToList()
                });
            }
            return View(new DisplayGoodsViewModel { Filter = filter, Goods = goods });
        }
    }
}