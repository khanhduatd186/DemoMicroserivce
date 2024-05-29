﻿using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DemoTuan6.Shared.Hosting.AspNetCore;

namespace DemoTuan6.DbMigrator;

class Program
{
    async static Task Main(string[] args)
    {
        var assemblyName = typeof(Program).Assembly.GetName().Name;

        SerilogConfigurationHelper.Configure(assemblyName!);

        await CreateHostBuilder(args).RunConsoleAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .AddAppSettingsSecretsJson()
            .ConfigureLogging((context, logging) => logging.ClearProviders())
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<DbMigratorHostedService>();
            });
}