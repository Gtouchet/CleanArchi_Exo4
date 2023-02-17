namespace CleanCalculator;

public class CalculatorCommand : Command
{
    public ECalculatorOperation Operation { get; set; }
    public List<int>? Content { get; set; }
}

public class CalculatorHandler : ConsoleWriter, ICommandHandler<CalculatorCommand>
{
    private readonly Logger logger;
    
    public CalculatorHandler(Logger logger)
    {
        this.logger = logger;
    }

    public void Handle(CalculatorCommand command)
    {
        int result = command.Content![0];
        this.WriteLine(" " + result);
        foreach (int value in command.Content.Skip(1))
        {
            result = command.Operation switch
            {
                ECalculatorOperation.Addition => result + value,
                ECalculatorOperation.Substraction => result - value,
                ECalculatorOperation.Multiplication => result * value,
                _ => throw new NotImplementedException(),
            };
            this.WriteLine($"{Utils.GetEnumDescription(command.Operation)}{value} (={result})");
        }
        this.WriteLine("-------");
        this.WriteLine($"total = {result} ({command.Operation})");
    }
}
