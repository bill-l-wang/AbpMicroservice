using Macro.AdministrationService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Macro.AdministrationService;

public abstract class AdministrationServiceController : AbpControllerBase
{
    protected AdministrationServiceController()
    {
        LocalizationResource = typeof(AdministrationServiceResource);
    }
}