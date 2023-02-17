using System.ComponentModel;

namespace CleanCalculator;

public enum ECommand
{
    calc,
}

public enum ECalculatorOperation
{
    [Description("+")]
    Addition,
    [Description("-")]
    Substraction,
    [Description("*")]
    Multiplication,
}

public class UserInputCommand
{
    public ECommand Command { get; private set; }
    public string? FilePath { get; private set; }
    public ECalculatorOperation Operation { get; private set; }

    public UserInputCommand ParseUserInput(string[] args)
    {
        this.Command = this.GetCommand(args[0]!);
        this.FilePath = args[1]!;
        if (this.Command.Equals(ECommand.calc))
        {
            this.Operation = this.GetOperation(args[2]!);
        }
        return this;
    }

    private ECommand GetCommand(string arg)
    {
        return arg switch
        {
            "calc" => ECommand.calc,
            // any other command
            _ => throw new NotImplementedException($"{arg} n'est pas une commande valide"),
        };
    }

    private ECalculatorOperation GetOperation(string arg)
    {
        return arg switch
        {
            "+" => ECalculatorOperation.Addition,
            "-" => ECalculatorOperation.Substraction,
            "*" => ECalculatorOperation.Multiplication,
            _ => throw new NotImplementedException($"{arg} n'est pas une operation valide"),
        };
    }
}
