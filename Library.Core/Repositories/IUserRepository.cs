using Library.Core.Models;

namespace Library.Core.Repositories;
public interface IUserRepository
{
    Task<User> CreateAsync(User user);
}
