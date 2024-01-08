using PhotoBooth.Data.Models;

namespace PhotoBooth.Managers.Contracts;

public interface IOrderManager
{
    IReadOnlyCollection<OrderItem> CreateOrder(string input, string boothId);
    void SaveOrder(IReadOnlyCollection<OrderItem> orderItems);
}
