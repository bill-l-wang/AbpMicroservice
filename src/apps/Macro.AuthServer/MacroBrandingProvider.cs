using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Macro;

[Dependency(ReplaceServices = true)]
public class MacroBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Macro";
}
