﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DemoTuan6.SaasService.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 * */
public class SaasServiceDbContextFactory : IDesignTimeDbContextFactory<SaasServiceDbContext>
{
    public SaasServiceDbContext CreateDbContext(string[] args)
    {
        SaasServiceEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<SaasServiceDbContext>()
            .UseSqlServer(GetConnectionStringFromConfiguration(), b =>
            {
                b.MigrationsHistoryTable("__SaasService_Migrations");
            });

        return new SaasServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration().GetConnectionString(SaasServiceDbProperties.ConnectionStringName)!;
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    $"..{Path.DirectorySeparatorChar}DemoTuan6.SaasService.HttpApi.Host"
                )
            )
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
