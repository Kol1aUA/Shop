using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAdoAspNet.Models
{
    public class DisplayGoodsViewModel
    {
        public GoodFilter Filter { get; set; }
        public IEnumerable<GoodViewModel> Goods { get; set; }
    }
}