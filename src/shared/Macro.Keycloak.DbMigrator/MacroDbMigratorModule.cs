﻿using Macro.Shared.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Macro.DbMigrator;

[DependsOn(
    typeof(MacroSharedHostingModule)
)]
public class MacroDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<KeycloakClientOptions>(options =>
            {
                options.Url = configuration["Keycloak:url"];
                options.AdminUserName = configuration["Keycloak:adminUsername"];
                options.AdminPassword = configuration["Keycloak:adminPassword"];
                options.RealmName = configuration["Keycloak:realmName"];
            }
        );
    }
}