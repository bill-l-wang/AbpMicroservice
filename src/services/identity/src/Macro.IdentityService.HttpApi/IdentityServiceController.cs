using Macro.IdentityService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Macro.IdentityService;

public abstract class IdentityServiceController : AbpControllerBase
{
    protected IdentityServiceController()
    {
        LocalizationResource = typeof(IdentityServiceResource);
    }
}