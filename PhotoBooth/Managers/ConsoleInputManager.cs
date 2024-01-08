using PhotoBooth.Managers.Contracts;

namespace PhotoBooth.Managers;

public class ConsoleInputManager : IInputManager<string>
{
    public string GetInputData()
    {
        var input = string.Empty;

        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Enter a sentence (cannot be empty):");
            input = Console.ReadLine();
        }

        return input;
    }
}
