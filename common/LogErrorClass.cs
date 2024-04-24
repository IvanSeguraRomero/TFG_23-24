using Microsoft.Extensions.Logging;
namespace TeatroWeb.common;
    public class LogErrorClass : IlogError{
    //logger
    public void LogErrorMethod(Exception ex, string message)
    {
        string folderPath = "../logs";
        // var logFilePath = "../logs/error-log.txt";
        // var logFilePath = "logs/error-log.txt";
        if (!Directory.Exists(folderPath)) {
        Directory.CreateDirectory(folderPath);
        }
        folderPath+="/error-log.txt";

        System.IO.File.AppendAllText(folderPath, $"{DateTime.Now.AddHours(1)} - {message}: {ex.Message}\n");

    }

    }
