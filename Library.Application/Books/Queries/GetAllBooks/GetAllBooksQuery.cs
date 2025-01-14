using Library.Application.Books.Dtos;

namespace Library.Application.Books.Queries.GetAllBooks;
public record GetAllBooksQuery : IRequest<IEnumerable<BookDto>>;
