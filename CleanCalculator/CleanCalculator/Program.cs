using CleanCalculator;

UserInputCommand userInput = new UserInputCommand().ParseUserInput(args);
FileParser fileParser = new FileParser();

Command command = userInput.Command switch
{
    ECommand.calc => new CalculatorCommand()
    {
        Operation = userInput.Operation,
        Content = fileParser.ParseAs<int>(filepath: userInput.FilePath!)
    },
    // any other command
    _ => throw new NotSupportedException("Cette command n'est pas supportée"),
};

bool log = true; // TODO avec args[3]
switch (command)
{
    case CalculatorCommand calculatorCommand:
        CalculatorHandler calculator = new CalculatorHandler(log ? Logger.GetInstance() : null);
        calculator.Handle(calculatorCommand);
        break;
    // any other command
}
