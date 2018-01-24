using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BestStore.Models;
using BestStore.Data.Interfaces;
namespace BestStore.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductRepository _productRepsoitory;

        public SearchController(IProductRepository productRepsoitory)
        {
            _productRepsoitory = productRepsoitory;
        }
        public async Task<ActionResult> Index([FromQuery] string keyword)
        {
            IEnumerable<Product> products = await _productRepsoitory.GetProductsAsync(keyword, 20, 1);
            return View();
        }
    }
}