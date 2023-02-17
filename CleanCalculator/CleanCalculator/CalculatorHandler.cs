namespace CleanCalculator;

public class CalculatorCommand : Command
{
    public ECalculatorOperation Operation { get; set; }
    public List<int>? Content { get; set; }
}

public class CalculatorHandler : ConsoleManager, ICommandHandler<CalculatorCommand>
{
    private readonly Logger? logger;
    private readonly bool log;

    public CalculatorHandler(Logger? logger = null)
    {
        this.logger = logger;
        this.log = logger != null;
    }

    public void Handle(CalculatorCommand command)
    {
        if (this.log) this.logger!.Log("started");
        
        int result = command.Content![0];
        this.WriteLine(" " + result);
        foreach (int value in command.Content.Skip(1))
        {
            if (this.log) this.logger!.Log($"applying operation {command.Operation}");
            result = command.Operation switch
            {
                ECalculatorOperation.Addition => result + value,
                ECalculatorOperation.Substraction => result - value,
                ECalculatorOperation.Multiplication => result * value,
                _ => throw new NotImplementedException(),
            };

            if (this.log) this.logger!.Log($"parsed value = {value}");
            this.WriteLine($"{Utils.GetEnumDescription(command.Operation)}{value} (={result})");
        }
        this.WriteLine("-------");
        this.WriteLine($"total = {result} ({command.Operation})");
    }
}
