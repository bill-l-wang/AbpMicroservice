using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Macro.Shared.Hosting.AspNetCore
{
    [Dependency(ReplaceServices = true)]
    public class MacroBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Macro";
    }
}
