using Library.Core.Models;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;

namespace Library.Infrastructure.Persistence.Repositories;
public class BookRepository(LibraryDbContext dbContext) : IBookRepository
{
    public async Task<Book> CreateAsync(Book newBook)
    {
        await dbContext.Books.AddAsync(newBook);
        await dbContext.SaveChangesAsync();
        return newBook;
    }

    public async Task<bool> DeleteByIdAsync(int id)
    {
        var dbBook = await dbContext.Books.FindAsync(id);

        if (dbBook == null)
        { 
            return false;
        }

        dbBook.SetAsDeleted();
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        var bookList = await dbContext
                        .Books
                        .Where(b  => !b.IsDeleted)
                        .AsNoTracking()
                        .ToListAsync();

        return bookList;
    }

    public async Task<Book>? GetByIdAsync(int id)
    {
        var book = await dbContext
            .Books.Where(b => b.Id == id && !b.IsDeleted)
            .FirstOrDefaultAsync();
        return book;
    }
}
