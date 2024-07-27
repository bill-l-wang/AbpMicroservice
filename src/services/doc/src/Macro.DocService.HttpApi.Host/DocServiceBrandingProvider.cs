using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DocService;

[Dependency(ReplaceServices = true)]
public class DocServiceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DocService";
}
