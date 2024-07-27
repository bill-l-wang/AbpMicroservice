using Xunit;

namespace DocService.EntityFrameworkCore;

[CollectionDefinition(DocServiceTestConsts.CollectionDefinitionName)]
public class DocServiceEntityFrameworkCoreCollection : ICollectionFixture<DocServiceEntityFrameworkCoreFixture>
{

}
