// See https://aka.ms/new-console-template for more information

using Assignment;
using Assignment.Factories;
using Assignment.Source;
using Assignment.Utilities;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


Arguements.Args = args;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddHostedService<ConsoleHostedService>()
        .AddSingleton<IConfigRepository, SqlConfigRepopsitory>()
        .AddSingleton<InventoryService>()
        .AddSingleton<ReaderFactory>()
        .AddSingleton<YamlReader>()
        .AddSingleton<JsonReader>()
        .AddSingleton<InputValidator>()
            )
    .Build();

host.RunAsync();

/* To-do
 * 1. Where to add DAL layer tests
 * 1. Base reader / Isource in Source - Which on is required...
 * 2. Repository pattern for db connection
 * 3. Add unit tests
 * 
 */