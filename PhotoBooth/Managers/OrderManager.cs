using PhotoBooth.Data.Models;
using PhotoBooth.Data.Services;
using PhotoBooth.Managers.Contracts;
using PhotoBooth.Strategies;

namespace PhotoBooth.Managers;

public class OrderManager : IOrderManager
{
    private readonly IDataService _dataService;
    private readonly Dictionary<string, Package> _availablePackages;
    private readonly List<string> _purchasedPackages;
    private readonly IVictoryStrategy _victoryStrategy;

    public OrderManager()
    {
        _dataService = new InMemoryDataService();
        _availablePackages = _dataService.GetAvailablePackages().ToDictionary(package => package.Id.ToString());
        _purchasedPackages = new List<string>();
        _victoryStrategy = new HourlyVictoryStrategy();
    }

    public IReadOnlyCollection<OrderItem> CreateOrder(string input, string boothId)
    {
        var result = new List<OrderItem>();

        while (true)
        {
            var unpurchasedPackages = _availablePackages.Where(f => !_purchasedPackages.Contains(f.Key)).ToList();
            if (!unpurchasedPackages.Any())
            {
                break;
            }

            Console.WriteLine("Choose a package you want to purchase (type '0' to skip):");
            foreach (var availablePackage in unpurchasedPackages)
            {
                Console.WriteLine($"{availablePackage.Key}. {availablePackage.Value.Name} (${availablePackage.Value.Price})");
            }

            var choice = Console.ReadLine();
            if (choice == "0")
            {
                break;
            }

            ProcessPackageChoice(choice, result, input, boothId);
        }

        ApplyLuckyCondition(result, boothId);

        return result;
    }

    public void SaveOrder(IReadOnlyCollection<OrderItem> orderItems)
    {
        _dataService.SaveOrder(orderItems);
    }

    private void ProcessPackageChoice(string choice, List<OrderItem> result, string input, string boothId)
    {
        if (_availablePackages.ContainsKey(choice))
        {
            var package = _availablePackages[choice];
            if (package != null)
            {
                result.Add(new OrderItem
                {
                    AmountPaid = package.Price,
                    BoothId = boothId,
                    Value = input,
                    Discount = 0,
                    PurchasedOn = DateTime.UtcNow,
                    Package = package
                });
                _purchasedPackages.Add(choice);
            }
            else
            {
                Console.WriteLine("Package not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please specify any of the available options.\n");
        }
    }

    private void ApplyLuckyCondition(List<OrderItem> result, string boothId)
    {
        if (_purchasedPackages.Count == _availablePackages.Count)
        {
            var isLucky = _victoryStrategy.IsLucky(boothId);
            if (isLucky)
            {
                var maxPrice = result.Max(item => item.AmountPaid);
                var freeItems = result.Where(item => item.AmountPaid != maxPrice).ToList();
                Console.WriteLine($"Congratulations! The following items are available for you for free: {string.Join(", ", freeItems.Select(item => item.Package.Name).ToArray())}");
                Console.WriteLine("Press any key to continue.");
                Console.Read();

                foreach (var item in freeItems)
                {
                    item.Discount = 100;
                }
            }
        }
    }
}
