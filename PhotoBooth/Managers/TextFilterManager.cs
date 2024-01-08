using PhotoBooth.Filters;
using PhotoBooth.Managers.Contracts;

namespace PhotoBooth.Managers;

public class TextFilterManager : IFilterManager<string, string>
{
    private readonly Dictionary<string, IFilter<string, string>> _availableFilters;
    private readonly List<string> _appliedFilters;

    public TextFilterManager()
    {
        _availableFilters = new Dictionary<string, IFilter<string, string>>
        {
            { "1", new MirrorScreenFilter() }
        };

        _appliedFilters = new List<string>();
    }

    public string ApplyFilters(string input)
    {
        string result = input;

        while (true)
        {
            var unappliedFilters = _availableFilters.Where(f => !_appliedFilters.Contains(f.Key)).ToList();
            if (!unappliedFilters.Any()) 
            { 
                break; 
            }

            Console.WriteLine("Choose a filter to apply (type '0' to skip):");
            foreach (var availableFilter in unappliedFilters)
            {
                Console.WriteLine($"{availableFilter.Key}. {availableFilter.Value}");
            }

            var choice = Console.ReadLine();

            if (choice == "0")
            {
                break;
            }

            result = ApplyFilter(choice, result);
        }

        return result;
    }

    private string ApplyFilter(string choice, string currentResult)
    {
        if (_availableFilters.ContainsKey(choice))
        {
            var filter = _availableFilters[choice];
            if (filter != null)
            {
                currentResult = filter.ApplyTo(currentResult);
                _appliedFilters.Add(choice);
                Console.WriteLine($"Result: {currentResult}\n");
            }
            else
            {
                Console.WriteLine("Filter not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please specify any of the available options.\n");
        }

        return currentResult;
    }
}
