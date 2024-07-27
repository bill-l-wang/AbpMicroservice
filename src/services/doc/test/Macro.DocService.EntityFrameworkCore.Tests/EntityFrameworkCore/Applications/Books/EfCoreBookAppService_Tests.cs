using DocService.Books;
using Xunit;

namespace DocService.EntityFrameworkCore.Applications.Books;

[Collection(DocServiceTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<DocServiceEntityFrameworkCoreTestModule>
{

}