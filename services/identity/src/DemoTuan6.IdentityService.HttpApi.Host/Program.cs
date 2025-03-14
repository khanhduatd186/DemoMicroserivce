using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DemoTuan6.Shared.Hosting.AspNetCore;
using Serilog;

namespace DemoTuan6.IdentityService;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        var assemblyName = typeof(Program).Assembly.GetName().Name;

        try
        {
            Log.Information($"Starting {assemblyName}.");
            var builder = WebApplication.CreateBuilder(args);
            
            SerilogConfigurationHelper.Configure(assemblyName!, builder.Environment.EnvironmentName);
            
            builder.Host
                .AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            await builder.AddApplicationAsync<IdentityServiceHttpApiHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, $"{assemblyName} terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
