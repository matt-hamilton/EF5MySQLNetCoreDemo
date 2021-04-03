using EF5MySQLNetCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EF5MySQLNetCoreDemo
{
    class Program
    {
        static ServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<IConsoleApplication>().Run();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("Connection");

            _serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddDbContext<ModelContext>(options => options.UseMySQL(connectionString))
                .AddSingleton<IConsoleApplication, ConsoleApplication>()
                .BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

    }
}
