using System.ComponentModel.DataAnnotations;

namespace Library.Core.Models;
public class Book : BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    [Required]
    public int PublishedYear { get; set; }
    public bool IsAvaliable { get; private set; } = true;
    public ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public void SetAsAvaliable()
    {
        IsAvaliable = true;
    }
    public void SetAsUnavaliable()
    {
        IsAvaliable = false; 
    }

}
