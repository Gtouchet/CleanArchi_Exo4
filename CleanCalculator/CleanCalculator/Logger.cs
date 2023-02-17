namespace CleanCalculator;

public class Logger : ConsoleManager
{
    private static Logger? instance;

    public static Logger GetInstance()
    {
        if (Logger.instance == null)
        {
            Logger.instance = new Logger();
        }
        return Logger.instance;
    }

    public void Log(string message)
    {
        this.WriteLine(DateTime.Now.ToString("[hhmmss:ffffff]") + "[log] " + message);
    }
}
