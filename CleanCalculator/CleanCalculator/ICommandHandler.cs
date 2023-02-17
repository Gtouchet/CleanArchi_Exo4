namespace CleanCalculator;

internal interface ICommandHandler<T> where T : Command
{
    void Handle(T command);
}
