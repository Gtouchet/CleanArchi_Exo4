namespace CleanCalculator;

public class FileParser
{
    public List<T> ParseAs<T>(string filepath) where T : struct // Only primitiv type
    {
        List<string> content = File.ReadLines(filepath).ToList();
        List<T> parsedContent = new List<T>();
        foreach (string line in content)
        {
            T parsedLine = (T)Convert.ChangeType(line, typeof(T));
            parsedContent.Add(parsedLine);
        }
        return parsedContent;
    }
}
