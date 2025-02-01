using Library.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace Library.Core.Models;
public class Book : BaseEntity
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    [Required]
    public int PublishedYear { get; private set; }
    public bool IsAvaliable { get; private set; }
    public ICollection<Loan> Loans { get; private set; } = new List<Loan>();

    public void SetAsAvaliable()
    {
        IsAvaliable = true;
    }
    public void SetAsUnavaliable()
    {
        IsAvaliable = false; 
    }


    private Book() { } // Entity Framework Constructor

    private Book(string title, string author, string isbn, int publishedYear)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublishedYear = publishedYear;
        IsAvaliable = true;
    }

    public static Result<Book> Create(string title, string author, string isbn, int publishedYear)
    {
        if(publishedYear <= 0)
        {
            return Result<Book>.Failure(BooksErrors.PublishedYearGreaterThanZero);
        }

        if (string.IsNullOrEmpty(title))
        {
            return Result<Book>.Failure(BooksErrors.TitleRequired);
        }

        if (string.IsNullOrEmpty(author))
        {
            return Result<Book>.Failure(BooksErrors.AuthorRequired);
        }

        if (string.IsNullOrEmpty(isbn))
        {
            return Result<Book>.Failure(BooksErrors.IsbnRequired);
        }

        return Result<Book>.Success(new Book(title, author, isbn, publishedYear));
    }

}
