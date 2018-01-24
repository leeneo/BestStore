using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BestStore.Data;
using BestStore.Data.Interfaces;
using BestStore.Models;
using BestStore.Web.Models;
using BestStore.Web.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace BestStore.Web.Controllers {
    public class HomeController : Controller {
        #region --- Private members ---
        private readonly IBrandRepository _brandRepository;
        private readonly IProductRepository _productRepository;
        private readonly int _maxProductCount = 50;
        #endregion

        public HomeController(IBrandRepository brandRepository, IProductRepository productRepository)
        {
            _brandRepository = brandRepository;
            _productRepository = productRepository;
        }
        //public IActionResult Index () {
        //    return View ();
        //}
        public async Task<IActionResult> Index()
        {
            if (!HttpContext.Session.Keys.Contains("UserSession"))
            {
                HttpContext.Session.Set("UserSession",
                  System.Text.Encoding.UTF8.GetBytes("SessionCreation"));
            }
            HomePageViewModel hvm = new HomePageViewModel();
            hvm.Brands = await _brandRepository.GetAllAsync();
            hvm.Products = (await _productRepository.GetPopularProductsAsync(_maxProductCount)).ToList();
            return View(hvm);
        }

        //public IActionResult IndexAsync () {
        //    return View ();
        //}

        public IActionResult About () {
            ViewData["Message"] = "Your application description page.";

            return View ();
        }

        public IActionResult Contact () {
            ViewData["Message"] = "Your contact page.";

            return View ();
        }

        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}