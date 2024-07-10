using Microsoft.EntityFrameworkCore;
using TestTask.Command.Database.Common;


namespace TestTask.Command.Database;

public class Context(DbContextOptions<Context> options) : ContextFactory(options)
{

}
