using Macro.Saas.Localization;
using Volo.Abp.Application.Services;

namespace Macro.Saas;

public abstract class SaasAppService : ApplicationService
{
    protected SaasAppService()
    {
        LocalizationResource = typeof(SaasResource);
        ObjectMapperContext = typeof(SaasApplicationModule);
    }
}