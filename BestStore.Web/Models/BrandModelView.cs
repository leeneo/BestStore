using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestStore.Models;

namespace BestStore.Web.Models
{
    public class BrandModelView
    {
        public Brand Brand { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
