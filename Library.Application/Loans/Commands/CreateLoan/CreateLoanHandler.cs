namespace Library.Application.Loans.Commands.CreateLoan;
public class CreateLoanHandler(IBookRepository bookRepository, ILoanRepository loanRepository, IUserRepository userRepository) : IRequestHandler<CreateLoanCommand, CreateLoanResult>
{
    public async Task<CreateLoanResult> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetByIdAsync(request.BookId);
        if (book == null)
        {
            return new CreateLoanResult(false, "Book doesn't exists");
        }

        if (!book.IsAvaliable)
        {
            return new CreateLoanResult(false, "Book isn't avaliable");
        }

        var user = await userRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            return new CreateLoanResult(false, "User doesn't exists");
        }

        var loan = new Loan()
        {
            UserId = request.UserId,
            BookId = request.BookId
        };

        book.SetAsUnavaliable();
        await loanRepository.CreateAsync(loan);

        return new CreateLoanResult(true, "");
    }
}
