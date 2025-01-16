namespace Library.Application.Users.CreateUser;
public record CreateUserCommand(string Name, string Email) : IRequest<CreateUserResult>;

public record CreateUserResult(int Id, string Name, string Email);