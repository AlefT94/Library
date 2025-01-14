namespace Library.Application.Books.Commands.DeleteBook;
public class DeleteBookHandler(IBookRepository repository) : IRequestHandler<DeleteBookCommand, bool>
{
    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await repository.GetByIdAsync(request.Id)!;

        if(book == null)
        {
            return false;
        }

        return await repository.DeleteByIdAsync(book.Id);
    }
}
