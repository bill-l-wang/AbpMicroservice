using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Macro.IdentityService.DbMigrations;
using Macro.IdentityService.EntityFrameworkCore;
using Macro.Shared.Hosting.Microservices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using Volo.Abp;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Macro.IdentityService;

[DependsOn(
    typeof(IdentityServiceApplicationModule),
    typeof(IdentityServiceApplicationModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceHttpApiModule),
    typeof(MacroSharedHostingMicroservicesModule)
)]
public class IdentityServiceHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<IdentityServiceDomainSharedModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        string.Format("..{0}..{0}src{0}Macro.IdentityService.Domain.Shared",
                            Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<IdentityServiceDomainModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        string.Format("..{0}..{0}src{0}Macro.IdentityService.Domain", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<IdentityServiceApplicationContractsModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        string.Format("..{0}..{0}src{0}Macro.IdentityService.Application.Contracts",
                            Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<IdentityServiceApplicationModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        string.Format("..{0}..{0}src{0}Macro.IdentityService.Application",
                            Path.DirectorySeparatorChar)));
            });
        }

        context.Services.AddAbpSwaggerGenWithOAuth(
            configuration["AuthServer:Authority"],
            new Dictionary<string, string> {
                {"IdentityService", "IdentityService API"}
            },
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "IdentityService API", Version = "v1"});
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });


        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                options.Audience = "IdentityService";
            });

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "IdentityService:";
        });

        var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("IdentityService");
        if (!hostingEnvironment.IsDevelopment())
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "IdentityService-Protection-Keys");
        }

        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        IdentityModelEventSource.ShowPII = true;
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();

        app.UseAbpRequestLocalization();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");

            var configuration = context.GetConfiguration();
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
            options.OAuthScopes("IdentityService");
        });
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }

    public override async Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        await context.ServiceProvider
            .GetRequiredService<IdentityServiceDatabaseMigrationChecker>()
            .CheckAndApplyDatabaseMigrationsAsync();
    }
}