using Microsoft.EntityFrameworkCore;
using TestTask.Command.Database;
using TestTask.Command.Database.Entity;

namespace TestTask.Command.Database.Common;

public abstract class ContextFactory : DbContext
{
    public ContextFactory()
    {
    }
    public ContextFactory(DbContextOptions<Context> options) : base(options) { }

    internal DbSet<ToDoItem> ToDoItems
    {
        get; set;
    }
    internal DbSet<User> Users
    {
        get; set;
    }
    internal DbSet<Priority> Priorities
    {
        get; set;
    }
}
