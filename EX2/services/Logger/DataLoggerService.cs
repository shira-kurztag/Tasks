using EX2.models;
using EX2.Repositories;
using Microsoft.EntityFrameworkCore;
namespace EX2.services.Logger;

    public class DataLoggerService: ILoggerService
    {
    private readonly TaskDBContext _dbContext;

    public DataLoggerService(TaskDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Log(string Message)
    {
        try
        {
            Logger2 l = new Logger2();
            l.Login = Message;
            _dbContext.Logger1.Add(l);
            _dbContext.SaveChanges();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"failed to log message{ ex.Message}");
        }
    }


   
}
