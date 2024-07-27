using AutoMapper;
using DocService.Books;

namespace DocService;

public class DocServiceApplicationAutoMapperProfile : Profile
{
    public DocServiceApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
