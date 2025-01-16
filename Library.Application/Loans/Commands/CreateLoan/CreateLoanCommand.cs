namespace Library.Application.Loans.Commands.CreateLoan;
public record CreateLoanCommand(int UserId, int BookId) : IRequest<CreateLoanResult>;

public record CreateLoanResult(bool isSuccess, string message);