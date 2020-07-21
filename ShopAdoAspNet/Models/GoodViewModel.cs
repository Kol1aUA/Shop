using ShopAdo.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopAdoAspNet.Models
{
    public class GoodViewModel
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public decimal GoodCount { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
        public IEnumerable<SelectListItem> Manufacturers { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}