// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using princess_choice.generator;
using princess_choice.model;
using princess_choice.writer;

class Program

{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    
    private static IHostBuilder CreateHostBuilder(string[] args)

    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>

            {
                services.AddScoped<ContenderNameGenerator>();

                services.AddScoped<IWriter, ContenderWriter>();
                
                services.AddHostedService<Princess>();

                services.AddScoped<IHall, Hall>();

                services.AddScoped<IFriend, Friend>();
            });
    }
}