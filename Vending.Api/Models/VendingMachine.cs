public class VendingMachine
{
    public int Id { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal TotalRevenue { get; set; }
    public string? SerialNumber { get; set; }
    public string? InventoryNumber { get; set; }
    public string Manufacturer { get; set; } = string.Empty;
    public DateTime ManufactureDate { get; set; }
    public DateTime CommissioningDate { get; set; }
    public DateTime LastCalibrationDate { get; set; }
    public int CalibrationIntervalMonths { get; set; }
    public int ResourceHours { get; set; }
    public DateTime NextMaintenanceDate { get; set; }
    public int MaintenanceDurationHours { get; set; }
    public string Status { get; set; } = string.Empty;
    public string ProductionCountry { get; set; } = string.Empty;
    public DateTime InventoryDate { get; set; }

    // public string LastCalibration { get; set; } = string.Empty;

    public int UserId { get; set; }
    public User? User { get; set; }
}
