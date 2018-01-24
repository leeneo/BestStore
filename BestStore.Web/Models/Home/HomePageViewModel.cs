using BestStore.Models;
using System.Collections.Generic;

namespace BestStore.Web.Models.Home
{
    public class HomePageViewModel
    {
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
