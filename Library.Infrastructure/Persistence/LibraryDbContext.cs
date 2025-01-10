using Library.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence;
public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Loan>(x =>
            {
                x.HasKey(l => l.Id);
                x.HasOne(l => l.Book)
                    .WithMany(b => b.Loans)
                    .HasForeignKey(l => l.BookId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Loan>(x =>
            {
                x.HasOne(l => l.User)
                    .WithMany(u => u.Loans)
                    .HasForeignKey(l => l.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        base.OnModelCreating(builder);
    }
}
