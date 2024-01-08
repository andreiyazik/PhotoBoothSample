using PhotoBooth.Managers;
using PhotoBooth.Managers.Contracts;

public class Program
{
    static IInputManager<string> _inputManager;
    static IFilterManager<string, string> _filterManager;
    static IOrderManager _orderManager;

    static void Main(string[] args)
    {
        _inputManager = new ConsoleInputManager();
        var input = _inputManager.GetInputData();

        _filterManager = new TextFilterManager();
        input = _filterManager.ApplyFilters(input);

        _orderManager = new OrderManager();
        var rnd = new Random();
        var orderItems = _orderManager.CreateOrder(input, rnd.Next(10000).ToString());
        _orderManager.SaveOrder(orderItems);
    }
}
