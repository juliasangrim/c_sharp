// See https://aka.ms/new-console-template for more information
using AttemptGenerator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PrincessChoice.Context;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
var configuration = builder.Build();
var optionsBuilder = new DbContextOptionsBuilder<PostgresDbContext>();
optionsBuilder.UseNpgsql(configuration.GetValue<string>("ConnectionStrings:DefaultConnection"));

using var db = new PostgresDbContext(optionsBuilder.Options);

var attemptCount = 100;
WorldGenerator.Generate(db, attemptCount);