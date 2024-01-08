using System.Text;

namespace PhotoBooth.Filters;

public class MirrorScreenFilter : IFilter<string, string>
{
    private const char SPACE = ' ';
    public string ApplyTo(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        var words = input.Split(SPACE);
        var result = new StringBuilder();

        for (int i = words.Length - 1; i >= 0; i--)
        {
            result.Append(words[i]);
            if (i > 0)
            {
                result.Append(SPACE);
            }
        }

        return result.ToString();
    }

    public override string ToString()
    {
        return "Mirror Screen";
    }
}
