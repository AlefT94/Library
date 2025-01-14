namespace Library.Application.Books.Commands.CreateBook;
public class CreateBookHandler(IBookRepository repository) : IRequestHandler<CreateBookCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        Book newBook = new()
        {
            Title = request.Title,
            Author = request.Author,
            ISBN = request.Isbn,
            PublishedYear = request.PublishedYear
        };

        await repository.CreateAsync(newBook);

        return Result<int>.Success(newBook.Id);
    }
}
