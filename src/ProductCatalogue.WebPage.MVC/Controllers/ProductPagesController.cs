using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductPages.Common.Data;
using ProductPages.Common.Models;

namespace ProductPages.WebPage.MVC.Controllers
{
    public class ProductPagesController : Controller
    {
        private readonly ProductPageContext _context;

        public ProductPagesController(ProductPageContext context)
        {
            _context = context;
        }

        // GET: ProductPages
        public async Task<IActionResult> Index(string sortOrder, string tagname)
        {
            
            var productPages = _context.ProductPages;
            if (productPages.Any())
            {

            }

            return View(await _context.ProductPages.ToListAsync());
        }

        // GET: ProductPages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPage = await _context.ProductPages
                .SingleOrDefaultAsync(m => m.Id == id);
            if (productPage == null)
            {
                return NotFound();
            }

            return View(productPage);
        }

        // GET: ProductPages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameOfProduct,MaintainerOfProduct,Created,CreatedBy,Updated,UpdatedBy,Description,SystemDocumentationUrl,TeamCityProjectUrl,OctopusDeployProjectUrl")] ProductPage productPage)
        {
            if (ModelState.IsValid)
            {
                productPage.Id = Guid.NewGuid();
                _context.Add(productPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productPage);
        }

        // GET: ProductPages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPage = await _context.ProductPages.SingleOrDefaultAsync(m => m.Id == id);
            if (productPage == null)
            {
                return NotFound();
            }
            return View(productPage);
        }

        // POST: ProductPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,NameOfProduct,MaintainerOfProduct,Created,CreatedBy,Updated,UpdatedBy,Description,SystemDocumentationUrl,TeamCityProjectUrl,OctopusDeployProjectUrl")] ProductPage productPage)
        {
            if (id != productPage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductPageExists(productPage.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productPage);
        }

        // GET: ProductPages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productPage = await _context.ProductPages
                .SingleOrDefaultAsync(m => m.Id == id);
            if (productPage == null)
            {
                return NotFound();
            }

            return View(productPage);
        }

        // POST: ProductPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var productPage = await _context.ProductPages.SingleOrDefaultAsync(m => m.Id == id);
            _context.ProductPages.Remove(productPage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductPageExists(Guid id)
        {
            return _context.ProductPages.Any(e => e.Id == id);
        }
    }
}
