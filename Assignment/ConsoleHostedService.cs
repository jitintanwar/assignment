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
            await serviceprovider.GetRequiredService<InventoryService>().Process(Arguements.Args[1], Arguements.Args[2]);
            hostApplicationLifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            hostApplicationLifetime.StopApplication();
            return Task.CompletedTask;
        }
    }
}
