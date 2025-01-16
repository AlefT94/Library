using Library.Core.Models;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence.Repositories;
public class LoanRepository(LibraryDbContext dbContext) : ILoanRepository
{
    public async Task<Loan?> CreateAsync(Loan loan)
    {
        var newLoan = loan;
        var book = await dbContext.Books.FindAsync(loan.BookId);
        var user = await dbContext.Users.FindAsync(loan.UserId);

        if (book is null || user is null)
        {
            return null;
        }

        await dbContext.AddAsync(newLoan);
        book.SetAsUnavaliable();

        await dbContext.SaveChangesAsync();
        return newLoan;
    }

    public async Task<Loan?> GetByIdAsync(int loandId)
    {
        var loan = await dbContext.Loans.FindAsync(loandId);
        return loan;
    }

    public async Task<List<Loan>> GetOverdueLoansAsync()
    {
        var overdueDate = DateTime.Now.Date.AddDays(-3);

        var loanList = await dbContext
            .Loans
            .Include(l => l.Book)
            .AsNoTracking()
            .Where(x=> x.LoanReturnDate == null)
            .Where(x=> x.LoanDate.Date < overdueDate)
            .ToListAsync();

        return loanList;
    }

    public async Task<bool> ReturnLoanAsync(int loanId)
    {
        var loanDb = await dbContext.Loans.FindAsync(loanId);
        if (loanDb == null)
        {
            return false;
        }

        var book = await dbContext.Books.FindAsync(loanDb.BookId);
        if (book is null)
        {
            return false;
        }

        loanDb.ReturnLoan();
        book.SetAsAvaliable();

        await dbContext.SaveChangesAsync();

        return true;
    }
}
