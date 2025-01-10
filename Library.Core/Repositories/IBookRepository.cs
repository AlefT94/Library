using Library.Core.Models;

namespace Library.Core.Repositories;
public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book>? GetByIdAsync(int id);
    Task<bool> DeleteByIdAsync(int id);
    Task<Book> CreateAsync(Book newBook);
}
