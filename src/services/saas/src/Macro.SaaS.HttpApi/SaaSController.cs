using Macro.Saas.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Macro.Saas;

public abstract class SaasController : AbpControllerBase
{
    protected SaasController()
    {
        LocalizationResource = typeof(SaasResource);
    }
}