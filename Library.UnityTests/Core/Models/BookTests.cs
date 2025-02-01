using Library.Core.Common;
using Library.Core.Models;

namespace Library.UnityTests.Core.Models;
public class BookTests
{
    [Fact]
    public void CreateBook_ValidData_ShouldCreateSuccessfuly()
    {
        // Arrange
        string title = "Clean Code";
        string author = "Robert C. Martin";
        string isbn = "1234567890123";
        int publishedYear = 2008;

        // Act
        var result = Book.Create(title, author, isbn, publishedYear);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Clean Code", result.Value.Title);
        Assert.Equal("Robert C. Martin", result.Value.Author);
        Assert.Equal("1234567890123", result.Value.ISBN);
        Assert.Equal(2008, result.Value.PublishedYear);
        Assert.True(result.Value.IsAvaliable);
    }

    [Theory]
    [InlineData("", "Robert C. Martin", "1234567890123", 2008)] // title empty
    [InlineData("Clean Code", "", "1234567890123", 2008)] // author empty
    [InlineData("Clean Code", "Robert C. Martin", null, 2008)] // ISBN invalid
    [InlineData("Clean Code", "Robert C. Martin", "1234567890123", 0)] // Year invalid
    public void CreateBook_InvalidData_ShouldReturnFailure(string title, string author, string isbn, int publishedYear)
    {
        // Act
        var result = Book.Create(title, author, isbn, publishedYear);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.NotNull(result.Error);

        if(title == "" || title == null)
        {
            Assert.Equal(BooksErrors.TitleRequired.Code, result.Error.Code);
        }
    }

    [Fact]
    public void SetAsUnavaliable_ValidCall_ShouldSetAsAvaliable()
    {
        // Arrange
        string title = "Clean Code";
        string author = "Robert C. Martin";
        string isbn = "1234567890123";
        int publishedYear = 2008;

        // Act
        var result = Book.Create(title, author, isbn, publishedYear);
        var book = result.Value;
        book.SetAsUnavaliable();

        // Assert
        Assert.False(book.IsAvaliable);
    }
}
