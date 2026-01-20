public class MaintenanceRecord
{
    public Guid Id { get; set; }
    public Guid VendingMachineId { get; set; }
    public VendingMachine? VendingMachine { get; set; }

    public DateTime MaintenanceDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Problems { get; set; } = string.Empty;

    public Guid MaintainerId { get; set; }
    public User? Maintainer { get; set; }
}
