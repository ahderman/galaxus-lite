using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GalaxusWebApi.Models;

namespace GalaxusWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly GalaxusDbContext _context;

    public ProductsController(GalaxusDbContext context)
    {
        _context = context;
    }

    // GET: api/Products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
    {
        if (_context.Products == null)
        {
            return NotFound();
        }
        return await _context.Products.Select(p => ProductDTO.FromProduct(p)).ToListAsync();
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProductById(uint id)
    {
        if (_context.Products == null)
        {
            return NotFound();
        }
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return ProductDTO.FromProduct(product);
    }

    // PUT: api/Products/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(uint id, ProductDTO productDTO)
    {
        if (id != productDTO.Id)
        {
            return BadRequest();
        }

        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        product.Name = productDTO.Name;
        product.Description = productDTO.Description;
        product.ImageUrl = productDTO.ImageUrl;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
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

    // POST: api/Products
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ProductDTO>> PostProduct(Product product)
    {
        if (_context.Products == null)
        {
            return Problem("Entity set 'GalaxusDbContext.Products'  is null.");
        }
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, ProductDTO.FromProduct(product));
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(uint id)
    {
        if (_context.Products == null)
        {
            return NotFound();
        }
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(uint id)
    {
        return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
