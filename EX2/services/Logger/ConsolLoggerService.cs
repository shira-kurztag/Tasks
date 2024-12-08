using System.Reflection;
namespace EX2.services.Logger
{
    public class ConsolLoggerService
    {
            public void Log(string message)
            {
                Console.WriteLine($"Log:{message}");
            }
        }
    }


