using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Macro.AdministrationService.Samples;

[Area(AdministrationServiceRemoteServiceConsts.ModuleName)]
[RemoteService(Name = AdministrationServiceRemoteServiceConsts.RemoteServiceName)]
[Route("api/Administration/sample")]
public class SampleServiceController : AdministrationServiceController, ISampleAppService
{
    private readonly ISampleAppService _sampleAppService;

    public SampleServiceController(ISampleAppService sampleAppService)
    {
        _sampleAppService = sampleAppService;
    }

    [HttpGet]
    public async Task<SampleDto> GetAsync()
    {
        return await _sampleAppService.GetAsync();
    }

    [HttpGet]
    [Route("authorized")]
    [Authorize]
    public async Task<SampleDto> GetAuthorizedAsync()
    {
        return await _sampleAppService.GetAsync();
    }
}