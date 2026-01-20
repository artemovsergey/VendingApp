public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int MinStock { get; set; }
    public Guid VendingMachineId { get; set; }
    public VendingMachine? VendingMachine { get; set; }
    public string Description { get; set; } = string.Empty;
    public int QuantityAvailable { get; set; }
    public decimal SalesTrend { get; set; }
}
