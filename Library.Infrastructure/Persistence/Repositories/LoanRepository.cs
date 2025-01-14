using Library.Core.Models;
using Library.Core.Repositories;

namespace Library.Infrastructure.Persistence.Repositories;
public class LoanRepository : ILoanRepository
{
    public Task<Loan> CreateAsync(Loan loan)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ReturnLoanAsync(int loanId)
    {
        throw new NotImplementedException();
    }
}
