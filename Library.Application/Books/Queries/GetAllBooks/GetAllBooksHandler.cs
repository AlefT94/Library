using Library.Application.Books.Dtos;
using Library.Core.Common;

namespace Library.Application.Books.Queries.GetAllBooks;
public class GetAllBooksHandler(IBookRepository repository) : IRequestHandler<GetAllBooksQuery, Result<IEnumerable<BookDto>>>
{
    public async Task<Result<IEnumerable<BookDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await repository.GetAllAsync();

        if(books == null)
        {
            return Result<IEnumerable<BookDto>>.Failure(BooksErrors.NotFound);
        }

        var response = books.Select(b => new BookDto(
            b.Id,
            b.Title,
            b.Author,
            b.ISBN,
            b.PublishedYear,
            b.IsAvaliable
        ));

        return Result<IEnumerable<BookDto>>.Success(response);
    }
}
