using DocService.Samples;
using Xunit;

namespace DocService.EntityFrameworkCore.Applications;

[Collection(DocServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<DocServiceEntityFrameworkCoreTestModule>
{

}
