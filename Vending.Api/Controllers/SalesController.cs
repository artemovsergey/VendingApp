using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vending.Api.Data;

namespace Vending.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly AppDbContext _context;

    public SalesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
    {
        return await _context.Sales.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Sale>> GetSale(Guid id)
    {
        var sale = await _context
            .Sales.Include(s => s.VendingMachineId)
            .Include(s => s.ProductId)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (sale == null)
            return NotFound();

        return sale;
    }

    [HttpPost]
    public async Task<ActionResult<Sale>> CreateSale(Sale sale)
    {
        if (!_context.VendingMachines.Any(vm => vm.Id == sale.VendingMachineId))
            return BadRequest("Аппарат не найден");

        if (!_context.Products.Any(p => p.Id == sale.ProductId))
            return BadRequest("Товар не найден");

        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSale), new { id = sale.Id }, sale);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSale(Guid id, Sale sale)
    {
        if (id != sale.Id)
            return BadRequest();

        _context.Entry(sale).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Sales.Any(e => e.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSale(int id)
    {
        var sale = await _context.Sales.FindAsync(id);
        if (sale == null)
            return NotFound();

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
