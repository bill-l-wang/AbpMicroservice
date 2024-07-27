using System;
using DocService.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace DocService.Books;

public class BookAppService :
    CrudAppService<
        Book, //The Book entity
        BookDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBookDto>, //Used to create/update a book
    IBookAppService //implement the IBookAppService
{
    public BookAppService(IRepository<Book, Guid> repository)
        : base(repository)
    {
        GetPolicyName = DocServicePermissions.Books.Default;
        GetListPolicyName = DocServicePermissions.Books.Default;
        CreatePolicyName = DocServicePermissions.Books.Create;
        UpdatePolicyName = DocServicePermissions.Books.Edit;
        DeletePolicyName = DocServicePermissions.Books.Delete;
    }
}