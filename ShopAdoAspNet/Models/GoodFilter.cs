using ShopAdo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAdoAspNet.Models
{
    public class GoodFilter
    {
        public double PriceFrom { get; set; }
        public double PriceTo { get; set; }
        public IList<CheckBoxFor<Category>> Categories { get; set; }
        public IList<CheckBoxFor<Manufacturer>> Manufacturers { get; set; }
    }
}