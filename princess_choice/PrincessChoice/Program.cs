// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddHostedService<Princess>();

                services.AddScoped<IStrategy, OptimalStrategy>();

                services.AddScoped<IWriter, ContenderWriter>();

                services.AddScoped<IHall, Hall>();

                services.AddScoped<IFriend, Friend>();
            });
    }
}