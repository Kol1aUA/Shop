using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAdoAspNet.Models
{
    public class CheckBoxFor<T>
    {
        public T Item { get; set; }
        public bool IsChecked { get; set; }
    }
}