using Library.Core.Models;

namespace Library.Core.Repositories;
public interface ILoanRepository
{
    Task<Loan?> CreateAsync(Loan loan);
    Task<bool> ReturnLoanAsync(int loanId);
    Task<Loan?> GetByIdAsync(int loandId);
}
