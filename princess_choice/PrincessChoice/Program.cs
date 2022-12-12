// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrincessChoice.Config;
using PrincessChoice.Context;
using PrincessChoice.Model;
using PrincessChoice.Strategy;
using PrincessChoice.Writer;

class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        string? attemptName = ParseAttemptName(args);

        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(builder =>
            {
                builder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
            })
            .ConfigureServices((hostBuilder, services) =>
            {
                services.AddHostedService<Executor>();

                services.AddScoped(_ => new AttemptConfig(attemptName));

                services.AddScoped<Princess>();

                services.AddScoped<IStrategy, OptimalStrategy>();

                services.AddScoped<IWriter, ContenderWriter>();

                services.AddScoped<IHall, HallDb>();

                services.AddScoped<IFriend, Friend>();

                services.AddDbContext<PostgresDbContext>(
                    o => o.UseNpgsql(
                        hostBuilder.Configuration.GetConnectionString("DefaultConnection"))
                );
            });
    }

    private static string? ParseAttemptName(string[] args)
    {
        try
        {
            return args.Length == 0 ? null : args[0];
        }
        catch (FormatException)
        {
            Console.WriteLine($"Format of attempt id not correct. Provided: {args[0]}, required: <int>");
            return null;
        }
    }
}