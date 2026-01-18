using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vending.Api.Data;

namespace Vending.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaintenanceController : ControllerBase
{
    private readonly AppDbContext _context;

    public MaintenanceController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MaintenanceRecord>>> GetMaintenanceRecords()
    {
        return await _context.MaintenanceRecords.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MaintenanceRecord>> GetMaintenanceRecord(int id)
    {
        var record = await _context.MaintenanceRecords.FirstOrDefaultAsync(m => m.Id == id);

        if (record == null)
            return NotFound();

        return record;
    }

    [HttpPost]
    public async Task<ActionResult<MaintenanceRecord>> CreateMaintenance(MaintenanceRecord record)
    {
        if (!_context.VendingMachines.Any(vm => vm.Id == record.VendingMachineId))
            return BadRequest("Аппарат не найден");

        _context.MaintenanceRecords.Add(record);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMaintenanceRecord), new { id = record.Id }, record);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMaintenance(int id, MaintenanceRecord record)
    {
        if (id != record.Id)
            return BadRequest();

        _context.Entry(record).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.MaintenanceRecords.Any(e => e.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMaintenance(int id)
    {
        var record = await _context.MaintenanceRecords.FindAsync(id);
        if (record == null)
            return NotFound();

        _context.MaintenanceRecords.Remove(record);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
