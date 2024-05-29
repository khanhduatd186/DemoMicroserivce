﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DemoTuan6.ProductService.Localization;
using DemoTuan6.ProductService.Permissions;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Authorization.Permissions;

namespace DemoTuan6.ProductService.Blazor.Menus;

public class ProductServiceMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }

    }

    private static async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<ProductServiceResource>();

        var moduleMenu = new ApplicationMenuItem(
            ProductServiceMenus.Prefix,
            l["Menu:ProductService"],
            icon: "fa fa-folder"
        );

        moduleMenu.AddItem(
            new ApplicationMenuItem(
                ProductServiceMenus.Products,
                l["Menu:Products"],
                url: "/Products"
            ).RequirePermissions(ProductServicePermissions.Products.Default));

        context.Menu.Items.AddIfNotContains(moduleMenu);
    }
}
