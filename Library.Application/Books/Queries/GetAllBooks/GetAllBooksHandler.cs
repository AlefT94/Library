using Library.Application.Books.Dtos;

namespace Library.Application.Books.Queries.GetAllBooks;
public class GetAllBooksHandler(IBookRepository repository) : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
{
    public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await repository.GetAllAsync();
        var response = books.Select(b => new BookDto(
            b.Id,
            b.Title,
            b.Author,
            b.ISBN,
            b.PublishedYear,
            b.IsAvaliable
        ));

        return response;
    }
}
