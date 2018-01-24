using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestStore.Data;
using BestStore.Data.Interfaces;
using BestStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BestStore.Web.Controllers {
    public class ProductsController : Controller {
        private readonly BestStoreDbContext _context;
        private readonly IProductImageRepository _prodImgRepo;
        private readonly IProductRepository _productRepo;
        public ProductsController (BestStoreDbContext context) {
            _context = context;
        }
        public ProductsController (IProductRepository productRepo, IProductImageRepository prodImgRepo) {
            _productRepo = productRepo;
            _prodImgRepo = prodImgRepo;
        }
        // GET: Products
        public async Task<IActionResult> Index () {
            //return View (await _context.Products.ToListAsync ()); //2.0
            return View(await _productRepo.GetAllAsync());//1.1

        }

        // GET: Products/Details/5
        [Route(template: "Product/{id}", Name = "ProductDetails")]
        public async Task<IActionResult> Details (Guid? id) {
            if (id == null) {
                return NotFound ();
            }

            Product product = await _productRepo.GetAsync((Guid)id);
            if (product == null)
            {
                return NotFound();
            }
            product.Images = await _prodImgRepo.GetProductImages(product.ProductID);
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create () {
            return View ();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create ([Bind ("ProductID,BrandID,CategoryID,ProductName,ThumbnailImage,Length,Height,Width,Weight,UnitofLength,UnitofWeight,UnitPrice,Currency,Description,CreatedTime,LastUpdateTime")] Product product) {
            if (ModelState.IsValid) {
                product.ProductID = Guid.NewGuid ();
                _context.Add (product);
                await _context.SaveChangesAsync ();
                return RedirectToAction (nameof (Index));
            }
            return View (product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit (Guid? id) {
            if (id == null) {
                return NotFound ();
            }

            var product = await _context.Products.SingleOrDefaultAsync (m => m.ProductID == id);
            if (product == null) {
                return NotFound ();
            }
            return View (product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (Guid id, [Bind ("ProductID,BrandID,CategoryID,ProductName,ThumbnailImage,Length,Height,Width,Weight,UnitofLength,UnitofWeight,UnitPrice,Currency,Description,CreatedTime,LastUpdateTime")] Product product) {
            if (id != product.ProductID) {
                return NotFound ();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update (product);
                    await _context.SaveChangesAsync ();
                } catch (DbUpdateConcurrencyException) {
                    if (!ProductExists (product.ProductID)) {
                        return NotFound ();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction (nameof (Index));
            }
            return View (product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete (Guid? id) {
            if (id == null) {
                return NotFound ();
            }

            var product = await _context.Products
                .SingleOrDefaultAsync (m => m.ProductID == id);
            if (product == null) {
                return NotFound ();
            }

            return View (product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed (Guid id) {
            var product = await _context.Products.SingleOrDefaultAsync (m => m.ProductID == id);
            _context.Products.Remove (product);
            await _context.SaveChangesAsync ();
            return RedirectToAction (nameof (Index));
        }

        private bool ProductExists (Guid id) {
            return _context.Products.Any (e => e.ProductID == id);
        }
    }
}