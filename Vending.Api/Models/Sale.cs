public class Sale
{
    public int Id { get; set; }

    public int VendingMachineId { get; set; }
    public VendingMachine? VendingMachine { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public int Quantity { get; set; }
    public decimal SaleAmount { get; set; }
    public DateTime SaleDateTime { get; set; }
    public Payment PaymentMethodSale { get; set; } = Payment.Cash; // или enum
}

public enum Payment
{
    Card = 0,
    Cash = 1,
    QrCode = 2,
}
