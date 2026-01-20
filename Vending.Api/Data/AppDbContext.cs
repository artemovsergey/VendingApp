using Microsoft.EntityFrameworkCore;

namespace Vending.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public required DbSet<VendingMachine> VendingMachines { get; set; }
    public required DbSet<Product> Products { get; set; }
    public required DbSet<Sale> Sales { get; set; }
    public required DbSet<User> Users { get; set; }
    public required DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(e =>
            e.ToTable(t => t.HasCheckConstraint("checkUserFio", "\"FullName\" != 'test'"))
        );

        // Реализовано ограничение на запрет дублирования по атрибутам серийноного и инвентарного номера

        modelBuilder.Entity<VendingMachine>(e => e.HasIndex(i => i.InventoryNumber).IsUnique());
        modelBuilder.Entity<VendingMachine>(e => e.HasIndex(i => i.SerialNumber).IsUnique());
    }
}
