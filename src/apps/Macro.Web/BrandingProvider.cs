using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Macro.Web;

[Dependency(ReplaceServices = true)]
public class BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Macro.Web";
}
