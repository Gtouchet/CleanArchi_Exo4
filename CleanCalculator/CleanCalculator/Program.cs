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

Logger logger = new Logger();
switch (command)
{
    case CalculatorCommand calculatorCommand:
        CalculatorHandler calculator = new CalculatorHandler(logger);
        calculator.Handle(calculatorCommand);
        break;
    // any other command
}
