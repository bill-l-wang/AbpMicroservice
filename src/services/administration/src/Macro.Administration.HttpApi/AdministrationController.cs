using Macro.Administration.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Macro.Administration;

public abstract class AdministrationController : AbpControllerBase
{
    protected AdministrationController()
    {
        LocalizationResource = typeof(AdministrationResource);
    }
}