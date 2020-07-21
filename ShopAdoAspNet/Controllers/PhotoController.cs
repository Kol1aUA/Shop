using ShopAdo.DAL;
using ShopAdo.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IRepository<Photo> _photoRepository;

        public PhotoController(IRepository<Photo> photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public ActionResult Delete(int id)
        {
            var photo = _photoRepository.Get(id);
            if (System.IO.File.Exists(photo.PhotoPath))
                System.IO.File.Delete(photo.PhotoPath);

            _photoRepository.Delete(photo);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}