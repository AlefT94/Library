namespace Library.Application.Books.Commands.CreateBook;
public class CreateBookHandler(IBookRepository repository) : IRequestHandler<CreateBookCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var newBookResult = Book.Create(request.Title, request.Author, request.Isbn, request.PublishedYear);

        if (!newBookResult.IsSuccess)
        {
            return Result<int>.Failure(newBookResult.Error);
        }

        await repository.CreateAsync(newBookResult.Value);

        return Result<int>.Success(newBookResult.Value.Id);
    }
}
