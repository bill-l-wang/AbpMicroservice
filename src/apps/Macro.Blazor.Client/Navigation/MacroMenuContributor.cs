using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.Users;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.Identity.Blazor;

namespace Macro.Blazor.Client.Navigation;

public class MacroMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public MacroMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private static async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 5;

        context.Menu.AddItem(new ApplicationMenuItem(
            MacroMenus.Home,
            "Home",
            "/",
            icon: "fas fa-home",
            order: 1
        ));
        //if (MultiTenancyConsts.IsEnabled)
        //{
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        //}
        //else
        //{
        //    administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        //}

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);
    
        var bookStoreMenu = new ApplicationMenuItem(
            "BooksStore",
            "Books",
            icon: "fa fa-book"
        );

        context.Menu.AddItem(bookStoreMenu);

        //CHECK the PERMISSION
        //if (await context.IsGrantedAsync(MacroPermissions.Books.Default))
        //{
        //    bookStoreMenu.AddItem(new ApplicationMenuItem(
        //        "BooksStore.Books",
        //        l["Menu:Books"],
        //        url: "/books"
        //    ));
        //}
    }
}
