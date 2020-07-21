using ShopAdo.DAL;
using ShopAdo.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IRepository<Manufacturer> _manufacturerRepository;

        public ManufacturerController()
        {
            _manufacturerRepository = new ManufacturerRepository();
        }

        public ActionResult Index()
        {
            return View(_manufacturerRepository.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_manufacturerRepository.Get(id));
        }

        public ActionResult Delete(int id)
        {
            _manufacturerRepository.Delete(_manufacturerRepository.Get(id));
            return RedirectToAction("Index", "Manufacturer");
        }

        public ActionResult Edit(int id)
        {
            return View(_manufacturerRepository.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Manufacturer manufacturer)
        {
            _manufacturerRepository.AddOrUpdate(manufacturer);
            return RedirectToAction("Index", "Manufacturer");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Manufacturer manufacturer)
        {
            _manufacturerRepository.AddOrUpdate(manufacturer);
            return RedirectToAction("Index", "Manufacturer");
        }
    }
}