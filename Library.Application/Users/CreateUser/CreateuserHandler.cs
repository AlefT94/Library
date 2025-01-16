
namespace Library.Application.Users.CreateUser;
public class CreateuserHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, CreateUserResult>
{
    public async Task<CreateUserResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
        };

        var createdUser = await userRepository.CreateAsync(user);

        return new CreateUserResult(createdUser.Id, createdUser.Name, createdUser.Email);
    }
}
