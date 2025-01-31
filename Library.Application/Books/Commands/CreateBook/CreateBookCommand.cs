namespace Library.Application.Books.Commands.CreateBook;
public record CreateBookCommand(string Title, string Author, string Isbn, int PublishedYear) : IRequest<Result<int>>;