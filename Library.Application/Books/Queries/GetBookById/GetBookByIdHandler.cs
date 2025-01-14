using Library.Application.Books.Dtos;

namespace Library.Application.Books.Queries.GetBookById;
public class GetBookByIdHandler(IBookRepository repository) : IRequestHandler<GetBookByIdQuery, BookDto>
{
    public async Task<BookDto>? Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await repository.GetByIdAsync(request.Id);
        
        if(book is null)
        {
            return null;
        }

        var result = new BookDto(book.Id, book.Title, book.Author, book.ISBN, book.PublishedYear, book.IsAvaliable);

        return result;
    }
}
