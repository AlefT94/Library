namespace Library.Core.Models;
public class User : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
