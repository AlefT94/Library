using Library.Application.Books.Dtos;
using Library.Core.Common;

namespace Library.Application.Books.Queries.GetAllBooks;
public record GetAllBooksQuery : IRequest<Result<IEnumerable<BookDto>>>;
