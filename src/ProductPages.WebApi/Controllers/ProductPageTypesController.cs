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
    [Route("api/ProductPageTypes")]
    public class ProductPageTypesController : Controller
    {
        private readonly ProductPageContext _context;

        public ProductPageTypesController(ProductPageContext context)
        {
            _context = context;
        }

        // GET: api/ProductPageTypes
        [HttpGet]
        public IEnumerable<ProductPageType> GetProductPageTypes()
        {
            return _context.ProductPageTypes;
        }

        // GET: api/ProductPageTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductPageType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productPageType = await _context.ProductPageTypes.SingleOrDefaultAsync(m => m.Id == id);

            if (productPageType == null)
            {
                return NotFound();
            }

            return Ok(productPageType);
        }

        // PUT: api/ProductPageTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductPageType([FromRoute] int id, [FromBody] ProductPageType productPageType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productPageType.Id)
            {
                return BadRequest();
            }

            _context.Entry(productPageType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPageTypeExists(id))
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

        // POST: api/ProductPageTypes
        [HttpPost]
        public async Task<IActionResult> PostProductPageType([FromBody] ProductPageType productPageType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductPageTypes.Add(productPageType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductPageType", new { id = productPageType.Id }, productPageType);
        }

        // DELETE: api/ProductPageTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductPageType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productPageType = await _context.ProductPageTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (productPageType == null)
            {
                return NotFound();
            }

            _context.ProductPageTypes.Remove(productPageType);
            await _context.SaveChangesAsync();

            return Ok(productPageType);
        }

        private bool ProductPageTypeExists(int id)
        {
            return _context.ProductPageTypes.Any(e => e.Id == id);
        }
    }
}