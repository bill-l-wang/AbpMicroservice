using Macro.SaaS.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Macro.SaaS;

public abstract class SaaSController : AbpControllerBase
{
    protected SaaSController()
    {
        LocalizationResource = typeof(SaaSResource);
    }
}