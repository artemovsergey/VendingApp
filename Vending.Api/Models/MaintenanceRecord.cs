public class MaintenanceRecord
{
    public int Id { get; set; }
    public int VendingMachineId { get; set; }
    public VendingMachine? VendingMachine { get; set; }

    public DateTime MaintenanceDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Problems { get; set; } = string.Empty;

    public int MaintainerId { get; set; }
    public User? Maintainer { get; set; }
}
