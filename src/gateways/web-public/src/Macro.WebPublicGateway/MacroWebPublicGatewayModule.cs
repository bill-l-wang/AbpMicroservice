﻿using Macro.Shared.Hosting.AspNetCore;
using Macro.Shared.Hosting.Gateways;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace Macro.WebPublicGateway;

[DependsOn(
    typeof(MacroSharedHostingGatewaysModule)
)]
public class MacroWebPublicGatewayModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        SwaggerConfigurationHelper.ConfigureWithOidc(
            context: context,
            authority: configuration["AuthServer:Authority"]!,
            scopes:
            [
                /* Requested scopes for authorization code request and descriptions for swagger UI only */
                "IdentityService",
                "AdministrationService",
                "ProjectsService",
                "DocService"
            ],
            apiTitle: "Web Gateway API",
            discoveryEndpoint: configuration["AuthServer:MetadataAddress"]
        );
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseSwaggerUIWithYarp(context);
        app.UseAbpSerilogEnrichers();

        app.UseRewriter(new RewriteOptions()
            // Regex for "", "/" and "" (whitespace)
            .AddRedirect("^(|\\|\\s+)$", "/swagger"));

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapReverseProxy();
        });
    }
}