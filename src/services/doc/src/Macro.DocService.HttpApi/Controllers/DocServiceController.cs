using DocService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DocService.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class DocServiceController : AbpControllerBase
{
    protected DocServiceController()
    {
        LocalizationResource = typeof(DocServiceResource);
    }
}
