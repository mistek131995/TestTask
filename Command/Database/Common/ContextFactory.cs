using Microsoft.EntityFrameworkCore;
using TestTask.Command.Database.Entity;

namespace TestTask.Command.Database.Common;

public abstract class ContextFactory : DbContext
{
    public ContextFactory()
    {
    }

    public ContextFactory(DbContextOptions<Context> options) : base(options) { }

    internal DbSet<User> Users { get; set; }
    internal DbSet<InputFile> InputFiles { get; set; }
    internal DbSet<OutputFile> OutputFiles { get; set; }
}
