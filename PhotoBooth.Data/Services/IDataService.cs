using PhotoBooth.Data.Models;

namespace PhotoBooth.Data.Services;

public interface IDataService
{
    IReadOnlyCollection<OrderItem> GetOrderItems(int month, int year);
    IReadOnlyCollection<Package> GetAvailablePackages();
    void SaveOrder(IReadOnlyCollection<OrderItem> orderItems);
}
