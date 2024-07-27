using DocService.Localization;
using Volo.Abp.Application.Services;

namespace DocService;

/* Inherit your application services from this class.
 */
public abstract class DocServiceAppService : ApplicationService
{
    protected DocServiceAppService()
    {
        LocalizationResource = typeof(DocServiceResource);
    }
}
