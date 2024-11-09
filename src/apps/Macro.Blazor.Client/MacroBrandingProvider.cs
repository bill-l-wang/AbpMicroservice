using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Macro.Blazor.Client;

[Dependency(ReplaceServices = true)]
public class MacroBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Macro";
}