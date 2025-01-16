using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Core.Models;
public class Loan : BaseEntity
{
    public int Id { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    public User User { get; set; }

    [ForeignKey("Book")]
    public int BookId { get; set; }

    public Book Book { get; set; }

    public DateTime LoanDate { get; set; } = DateTime.Now;
    public DateTime? LoanReturnDate { get; private set; } = null;

    public void ReturnLoan()
    {
        LoanReturnDate = DateTime.Now;
    }
}
