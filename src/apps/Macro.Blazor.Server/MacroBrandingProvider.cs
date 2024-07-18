using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Macro.Blazor.Server;

[Dependency(ReplaceServices = true)]
public class MacroBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Macro";
}
