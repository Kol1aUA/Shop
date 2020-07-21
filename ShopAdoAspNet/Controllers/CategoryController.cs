using ShopAdo.DAL;
using ShopAdo.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ActionResult Index()
        {
            return View(_categoryRepository.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_categoryRepository.Get(id));
        }

        public ActionResult Delete(int id)
        {
            _categoryRepository.Delete(_categoryRepository.Get(id));
            return RedirectToAction("Index", "Category");
        }

        public ActionResult Edit(int id)
        {
            return View(_categoryRepository.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            _categoryRepository.AddOrUpdate(category);
            return RedirectToAction("Index", "Category");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            _categoryRepository.AddOrUpdate(category);
            return RedirectToAction("Index", "Category");
        }
    }
}