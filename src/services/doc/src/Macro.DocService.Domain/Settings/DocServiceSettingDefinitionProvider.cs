using Volo.Abp.Settings;

namespace DocService.Settings;

public class DocServiceSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(DocServiceSettings.MySetting1));
    }
}
