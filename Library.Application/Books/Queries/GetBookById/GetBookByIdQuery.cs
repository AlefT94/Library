using Library.Application.Books.Dtos;

namespace Library.Application.Books.Queries.GetBookById;
public record GetBookByIdQuery(int Id) : IRequest<BookDto>;

