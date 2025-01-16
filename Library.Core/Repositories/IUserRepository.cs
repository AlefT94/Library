using Library.Core.Models;

namespace Library.Core.Repositories;
public interface IUserRepository
{
    Task<User> CreateAsync(User user);

    Task<User> GetByIdAsync(int id);
}
