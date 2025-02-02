using Library.Application.Books.Commands.DeleteBook;
using Library.Core.Models;
using Library.Core.Repositories;
using NSubstitute;
using System.Net;

namespace Library.UnityTests.Application.Books;
public class DeleteBookTests
{
    [Fact]
    public async Task BookExists_Delete_Success()
    {
        //Arrange
        string title = "Clean Code";
        string author = "Robert C. Martin";
        string isbn = "1234567890123";
        int publishedYear = 2008;
        var resultValidBook = Book.Create(title, author, isbn, publishedYear);
        var validBook = resultValidBook.Value;

        var repository = Substitute.For<IBookRepository>();
        var handler = new DeleteBookHandler(repository);
        var command = new DeleteBookCommand(7);

        repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult((Book?)validBook));
        repository.DeleteByIdAsync(Arg.Any<int>()).Returns(Task.FromResult(true));

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.True(result);
        await repository.Received().DeleteByIdAsync(Arg.Any<int>());
    }

    [Fact]
    public async Task BookDoesNotExists_Delete_False()
    {
        //Arrange

        var repository = Substitute.For<IBookRepository>();
        var handler = new DeleteBookHandler(repository);
        var command = new DeleteBookCommand(7);

        repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult((Book?)null));
        repository.DeleteByIdAsync(Arg.Any<int>()).Returns(Task.FromResult(true));

        //Act
        var result = await handler.Handle(command, new CancellationToken());

        //Assert
        Assert.False(result);
        await repository.DidNotReceive().DeleteByIdAsync(Arg.Any<int>());
    }
}
