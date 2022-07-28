using Assignment.Factories;
using Assignment.Source;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class ConsoleHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime hostApplicationLifetime;
        private readonly IServiceProvider serviceprovider;

        public ConsoleHostedService(IHostApplicationLifetime hostApplicationLifetime, IServiceProvider serviceProvider)
        {
            this.hostApplicationLifetime = hostApplicationLifetime;
            this.serviceprovider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Execute();

        }

        private async Task Execute()
        {
            do
            {
                Console.WriteLine("Please input your command.");

                var inputs = Console.ReadLine();
                string[] args = inputs.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (ValidateArgs(args))
                {
                    try
                    {
                        await serviceprovider.GetRequiredService<InventoryService>().Process(args[1], args[2]);
                    }
                    catch (ApplicationException ex)
                    {
                        Console.WriteLine($"Invalid command {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing command {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command. Please try again.");
                }
                Console.WriteLine("Press Enter to continue or Esc to exit.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private bool ValidateArgs(string[] args)
        {
            if (args.Length != 3)
                return false;

            // args[0] validation
            if (string.IsNullOrEmpty(args[0]) || !args[0].Equals("import"))
                return false;

            // args[2] validation
            if (string.IsNullOrEmpty(args[2]) || !File.Exists(args[2]))
                return false;

            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            hostApplicationLifetime.StopApplication();
            return Task.CompletedTask;
        }
    }
}
