namespace Library.Application.Loans.Commands.ReturnLoan;
public record ReturnLoanCommand(int loandId) : IRequest<bool>;
