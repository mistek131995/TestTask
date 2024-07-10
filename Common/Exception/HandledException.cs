namespace TestTask.Common.Exception;

public class HandledException : System.Exception
{
    public bool WriteToLog { get; set; }
    public List<string> Messages { get; set; }

    public HandledException(string message, bool writeToLog = false)
    {
        WriteToLog = writeToLog;
        Messages = new List<string>()
        {
            message,
        };
        
    }

    public HandledException(Dictionary<string, string[]> messages, bool writeToLog = false)
    {
        WriteToLog = writeToLog;
        Messages = messages.SelectMany(x => x.Value).ToList();
    }
}
