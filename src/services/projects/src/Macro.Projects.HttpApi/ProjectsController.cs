using Macro.Projects.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Macro.Projects;

public abstract class ProjectsController : AbpControllerBase
{
    protected ProjectsController()
    {
        LocalizationResource = typeof(ProjectsResource);
    }
}