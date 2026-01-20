public class VendingMachine
{
    public Guid Id { get; set; }
    public required string SerialNumber { get; set; } = string.Empty;
    public required string InventoryNumber { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string ModelType { get; set; } = string.Empty;
    public decimal TotalIncome { get; set; }
    public string Company { get; set; } = string.Empty;
    public DateOnly ManufacterDate { get; set; }
    public DateOnly InstallDate { get; set; }
    public DateOnly LastMaintainceDate { get; set; }
    public int MaintainceMonthInterval { get; set; } = 12;
    public int ResourceHours { get; set; }
    public DateOnly NextMainainceDate { get; set; }
    public int ServiceTime { get; set; }
    public string Status { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public DateOnly InventoryDate { get; set; }

    public Guid? MaintainerId { get; set; }
    public User? Maintainer { get; set; }
}

public enum ModelType
{
    Card = 0,
    Money = 1,
    CardAndMoney = 2,
}

public enum Status
{
    Job,
    NotJob,
    Service,
}
