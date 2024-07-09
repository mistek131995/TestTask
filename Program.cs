using Microsoft.EntityFrameworkCore;
using TestTask.Command.Database;

namespace TestTask;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("mssql");
        builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString, options => options.EnableRetryOnFailure()));

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider
                .GetRequiredService<Context>();

            await dbContext.Database.MigrateAsync();
        }

        app.UseAuthorization();
        app.UseStaticFiles();


        app.MapControllers();
        app.MapFallbackToFile("/index.html");

        app.Run();
    }
}
