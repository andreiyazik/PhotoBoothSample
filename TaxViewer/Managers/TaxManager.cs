using PhotoBooth.Data.Services;
using TaxViewer.Strategies;

namespace TaxViewer.Managers;

public class TaxManager : ITaxManager
{
    private readonly IDataService _dataService;
    private readonly Dictionary<string, ITaxCalculationStrategy> _taxCalculationStrategies;

    public TaxManager()
    {
        _dataService = new InMemoryDataService();
        _taxCalculationStrategies = new Dictionary<string, ITaxCalculationStrategy>
        {
            { "1", new NewYorkLongIslandTaxCalculationStrategy() },
        };
    }

    public decimal CalculateTax(int month, int year)
    {
        decimal result = 0;

        var taxStrategy = GetTaxCalculationStrategy();
        if(taxStrategy != null)
        {
            var orderItems = _dataService.GetOrderItems(month, year);
            result = taxStrategy.Calculate(orderItems);
        }

        return result;
    }

    private ITaxCalculationStrategy GetTaxCalculationStrategy()
    {
        ITaxCalculationStrategy taxStrategy = null;
        while (true)
        {
            Console.WriteLine("Choose a region to calculate tax for (type '0' to skip):");
            foreach (var strategy in _taxCalculationStrategies)
            {
                Console.WriteLine($"{strategy.Key}. {strategy.Value}");
            }

            var choice = Console.ReadLine();

            if (choice == "0")
            {
                break;
            }

            if (!_taxCalculationStrategies.ContainsKey(choice))
            {
                Console.WriteLine("Invalid choice. Please specify any of the available options.\n");
            }
            else
            {
                taxStrategy = _taxCalculationStrategies[choice];
            }
        }

        return taxStrategy;
    }
}
