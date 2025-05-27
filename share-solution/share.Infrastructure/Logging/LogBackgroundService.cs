using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using share.Application.Interfaces;
using share.Infrastructure.EFCore.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Infrastructure.Logging
{
    public class LogBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogQueue _logQueue;

        public LogBackgroundService(IServiceProvider serviceProvider, ILogQueue logQueue)
        {
            _serviceProvider = serviceProvider;
            _logQueue = logQueue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logQueue.TryDequeue(out var log))
                {
                    using var scope = _serviceProvider.CreateScope();
                    var dbContext = scope.ServiceProvider.GetRequiredService<ShareDbContext>();
                    dbContext.Logs.Add(log);
                    await dbContext.SaveChangesAsync(stoppingToken);
                }

                await Task.Delay(100, stoppingToken); // tránh CPU 100%
            }
        }
    }
}
