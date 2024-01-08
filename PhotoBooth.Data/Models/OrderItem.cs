namespace PhotoBooth.Data.Models;

public class OrderItem
{
    public Package Package { get; set; }
    public string Value { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal Discount { get; set; }
    public DateTime PurchasedOn { get; set; }
    public string BoothId { get; set; }
}
