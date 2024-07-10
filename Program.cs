using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TestTask.Command.Database;
using TestTask.Command.Database.Common;
using TestTask.Command.Database.Repository;
using TestTask.Common.Extension;
using TestTask.Common.Mediatr;


namespace TestTask;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("mssql");
        builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString, options => options.EnableRetryOnFailure()));
        builder.Services.AddScoped<Query.Common.IConnectionFactory, Query.Common.ConnectionFactory>(x => new Query.Common.ConnectionFactory(connectionString));

        builder.Services.AddScoped<IRepositoryProvider, RepositoryProvider>();
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.AddExceptionMiddlewareExtension();

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
