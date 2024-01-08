using PhotoBooth.Data.Models;

namespace PhotoBooth.Data.Services;

public class InMemoryDataService : IDataService
{
    private readonly List<OrderItem> _orderItems;

    public InMemoryDataService()
    {
        _orderItems = new List<OrderItem>();
    }

    public IReadOnlyCollection<OrderItem> GetOrderItems(int month, int year)
    {
        return _orderItems.Where(item => item.PurchasedOn.Month == month && item.PurchasedOn.Year == year).ToList();
    }

    public IReadOnlyCollection<Package> GetAvailablePackages()
    {
        return new List<Package>
        {
            new Package { Id = 1, Name = "Prints", Type = PackageType.Prints, Price = 5 },
            new Package { Id = 2, Name = "Panorama", Type = PackageType.Panorama, Price = 7 },
            new Package { Id = 3, Name = "Strips", Type = PackageType.Strips, Price = 5 }
        };
    }

    public void SaveOrder(IReadOnlyCollection<OrderItem> orderItems)
    {
        _orderItems.AddRange(orderItems);
    }
}
