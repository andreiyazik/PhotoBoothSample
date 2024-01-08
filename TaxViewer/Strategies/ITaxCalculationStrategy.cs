using PhotoBooth.Data.Models;

namespace TaxViewer.Strategies;

public interface ITaxCalculationStrategy
{
    decimal Calculate(IReadOnlyCollection<OrderItem> orderItems);
}
