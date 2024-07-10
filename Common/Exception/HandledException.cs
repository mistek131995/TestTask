namespace TestTask.Common.Exception;

public class HandledException(string message, bool writeToLog = false) : System.Exception(message)
{
    public bool WriteToLog = writeToLog;
}
