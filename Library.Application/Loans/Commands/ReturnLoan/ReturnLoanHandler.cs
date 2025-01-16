
namespace Library.Application.Loans.Commands.ReturnLoan;
public class ReturnLoanHandler(ILoanRepository loanRepository, IBookRepository bookRepository) : IRequestHandler<ReturnLoanCommand, bool>
{
    public async Task<bool> Handle(ReturnLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await loanRepository.GetByIdAsync(request.loandId);
        if (loan == null)
        {
            return false;
        }

        var book = await bookRepository.GetByIdAsync(loan.BookId);

        book.SetAsAvaliable();
        return await loanRepository.ReturnLoanAsync(request.loandId);
    }
}
