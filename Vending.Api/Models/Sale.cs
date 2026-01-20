public class Sale
{
    public Guid Id { get; set; }

    public Guid VendingMachineId { get; set; }
    public VendingMachine? VendingMachine { get; set; }

    public Guid ProductId { get; set; }
    public Product? Product { get; set; }

    public int Quantity { get; set; }
    public decimal SaleAmount { get; set; }
    public DateTime SaleDateTime { get; set; }
    public Payment PaymentMethodSale { get; set; }
}

public enum Payment
{
    Money = 0,
    Qr = 1,
    Card = 2,
}
