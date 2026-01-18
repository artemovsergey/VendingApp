using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vending.Api.Data;

namespace Vending.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendingMachinesController : ControllerBase
{
    private readonly AppDbContext _context;

    public VendingMachinesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VendingMachine>>> GetVendingMachines()
    {
        return await _context.VendingMachines.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VendingMachine>> GetVendingMachine(int id)
    {
        var machine = await _context.VendingMachines.FindAsync(id);

        if (machine == null)
        {
            return NotFound();
        }

        return machine;
    }

    [HttpPost]
    public async Task<ActionResult<VendingMachine>> CreateVendingMachine(VendingMachine machine)
    {
        if (await _context.VendingMachines.AnyAsync(m => m.SerialNumber == machine.SerialNumber))
            return BadRequest("ТА с таким серийным номером уже существует");

        if (await _context.VendingMachines.AnyAsync(m => m.Id == machine.Id))
            return BadRequest("ТА с таким инвентарным номером уже существует");

        _context.VendingMachines.Add(machine);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVendingMachine), new { id = machine.Id }, machine);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVendingMachine(int id, VendingMachine machine)
    {
        if (id != machine.Id)
        {
            return BadRequest();
        }

        _context.Entry(machine).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.VendingMachines.Any(e => e.Id == id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVendingMachine(string id)
    {
        var machine = await _context.VendingMachines.FindAsync(id);
        if (machine == null)
        {
            return NotFound();
        }

        _context.VendingMachines.Remove(machine);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
