using Library.Application.Books.Commands.CreateBook;
using Library.Core.Common;
using Library.Core.Models;
using Library.Core.Repositories;
using NSubstitute;

namespace Library.UnityTests.Application.Books;
public class CreateBookTests
{
    [Fact]
    public async Task ValidBookData_HandleIsCalled_ShouldReturnSuccessAsync()
    {
        // Arrange
        var respository = Substitute.For<IBookRepository>();

        string title = "Clean Code";
        string author = "Robert C. Martin";
        string isbn = "1234567890123";
        int publishedYear = 2008;
        var command = new CreateBookCommand(title, author, isbn, publishedYear);

        var handler = new CreateBookHandler(respository);

        // Act
        var result = await handler.Handle(command, new CancellationToken());

        // Assert
        Assert.True(result.IsSuccess);
        //await respository.Received(1).CreateAsync();
    }

    [Fact]
    public async Task InvalidBookData_HandleIsCalled_ShouldReturnFailureAsync()
    {
        // Arrange
        var repository = Substitute.For<IBookRepository>();

        string title = "";
        string author = "Robert C. Martin";
        string isbn = "1234567890123";
        int publishedYear = 2008;
        var command = new CreateBookCommand(title, author, isbn, publishedYear);

        var handler = new CreateBookHandler(repository);

        // Act
        var result = await handler.Handle(command, new CancellationToken());

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal(BooksErrors.TitleRequired.Code, result.Error.Code);
        await repository.DidNotReceive().CreateAsync(Arg.Any<Book>());
    }
}
