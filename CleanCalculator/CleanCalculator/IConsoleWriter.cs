namespace CleanCalculator;

public abstract class ConsoleWriter
{
    protected void WriteLine(string message) => Console.WriteLine(message);
    protected void Write(string message) => Console.Write(message);
    protected string? Read() => Console.ReadLine();
}
