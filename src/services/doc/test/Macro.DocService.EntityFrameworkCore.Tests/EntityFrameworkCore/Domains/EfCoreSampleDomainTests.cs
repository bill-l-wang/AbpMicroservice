using DocService.Samples;
using Xunit;

namespace DocService.EntityFrameworkCore.Domains;

[Collection(DocServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<DocServiceEntityFrameworkCoreTestModule>
{

}
