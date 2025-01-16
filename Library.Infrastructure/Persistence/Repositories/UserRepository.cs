using Library.Core.Models;
using Library.Core.Repositories;

namespace Library.Infrastructure.Persistence.Repositories;
public class UserRepository(LibraryDbContext dbContext) : IUserRepository
{
    public async Task<User> CreateAsync(User user)
    {
        var newUser = user;
        await dbContext.AddAsync(newUser);
        await dbContext.SaveChangesAsync();

        return newUser;
    }

    public async Task<User> GetByIdAsync(int id) => await dbContext.Users.FindAsync(id);
}
