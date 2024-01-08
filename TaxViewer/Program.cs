using TaxViewer.Managers;

public class Program
{
    private static ITaxManager _taxManager;

    static void Main(string[] args)
    {
        int month = ReadValidMonth();
        int year = ReadValidYear();

        Console.WriteLine($"You have entered: Month = {month}, Year = {year}");

        _taxManager = new TaxManager();
    }

    private static int ReadValidMonth()
    {
        int month;
        while (true)
        {
            Console.Write("Enter a month (1-12): ");
            if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12)
            {
                return month;
            }
            Console.WriteLine("Invalid month. Please enter a number between 1 and 12.");
        }
    }

    private static int ReadValidYear()
    {
        int year;
        while (true)
        {
            Console.Write("Enter a year: ");
            if (int.TryParse(Console.ReadLine(), out year) && year > 0)
            {
                return year;
            }
            Console.WriteLine("Invalid year. Please enter a positive integer.");
        }
    }
}