using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductPages.Common.Data;
using ProductPages.Common.Models;

namespace ProductPages.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductPages")]
    public class ProductPagesController : Controller
    {
        private readonly ProductPageContext _context;

        public ProductPagesController(ProductPageContext context)
        {
            _context = context;
        }

        // GET: api/ProductPages
        [HttpGet]
        public IEnumerable<ProductPage> GetProductPages()
        {
            return _context.ProductPages;
        }

        // GET: api/ProductPages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductPage([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productPage = await _context.ProductPages.SingleOrDefaultAsync(m => m.Id == id);

            if (productPage == null)
            {
                return NotFound();
            }

            return Ok(productPage);
        }

        // PUT: api/ProductPages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductPage([FromRoute] Guid id, [FromBody] ProductPage productPage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productPage.Id)
            {
                return BadRequest();
            }

            _context.Entry(productPage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductPages
        [HttpPost]
        public async Task<IActionResult> PostProductPage([FromBody] ProductPage productPage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductPages.Add(productPage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductPage", new { id = productPage.Id }, productPage);
        }

        // DELETE: api/ProductPages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductPage([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productPage = await _context.ProductPages.SingleOrDefaultAsync(m => m.Id == id);
            if (productPage == null)
            {
                return NotFound();
            }

            _context.ProductPages.Remove(productPage);
            await _context.SaveChangesAsync();

            return Ok(productPage);
        }

        private bool ProductPageExists(Guid id)
        {
            return _context.ProductPages.Any(e => e.Id == id);
        }
    }
}