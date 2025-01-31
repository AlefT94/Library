using Library.Application.Books.Dtos;

namespace Library.Application.Books.Queries.GetBookById;
public class GetBookByIdHandler(IBookRepository repository) : IRequestHandler<GetBookByIdQuery, Result<BookDto>>
{
    public async Task<Result<BookDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        Book? book = await repository.GetByIdAsync(request.Id);
        
        if(book is null)
        {
            return Result<BookDto>.Failure(BooksErrors.NotFound);
        }

        var resultDto = new BookDto(book.Id, book.Title, book.Author, book.ISBN, book.PublishedYear, book.IsAvaliable);

        return Result<BookDto>.Success(resultDto);
    }
}
