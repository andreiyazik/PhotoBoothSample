using PhotoBooth.Data.Models;

namespace TaxViewer.Strategies;

public interface ITaxStrategy
{
    decimal CalculateTax(IReadOnlyCollection<OrderItem> orderItems);
}
