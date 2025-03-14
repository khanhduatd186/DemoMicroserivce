using System;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DemoTuan6.AuthServer.Pages;

public class IndexModel : AbpPageModel
{
    public ActionResult OnGet()
    {
        if (Request.Query["ex"] == "yes")
        {
            throw new DivideByZeroException("This is a test exception!");
        }
    
        if (!CurrentUser.IsAuthenticated)
        {
            return Redirect("~/Account/Login");
        }
        else
        {
            return Page();
        }
    }
}
