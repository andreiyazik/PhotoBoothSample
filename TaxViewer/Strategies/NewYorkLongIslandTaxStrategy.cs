using PhotoBooth.Data.Models;

namespace TaxViewer.Strategies;

public class NewYorkLongIslandTaxStrategy : ITaxStrategy
{
    private const decimal TAX_PERCENTAGE = 8.625M;

    public decimal CalculateTax(IReadOnlyCollection<OrderItem> orderItems)
    {
        decimal total = 0;

        var paidItems = orderItems.Where(item => item.Discount < 100).ToList();
        foreach (var orderItem in paidItems)
        {
            total += orderItem.Discount == 0 ? orderItem.AmountPaid : orderItem.AmountPaid - (orderItem.AmountPaid / 100 * orderItem.Discount);
        }

        return total == 0 ? 0 : total / 100 * TAX_PERCENTAGE;
    }
}
