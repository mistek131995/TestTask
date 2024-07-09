using Microsoft.EntityFrameworkCore;
using TestTask.Command.Database.Entity;


namespace TestTask.Command.Database;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{

    internal DbSet<ToDoItem> ToDoItems { get; set; }
    internal DbSet<User> Users { get; set; }
    internal DbSet<Priority> Priorities { get; set; }
}
