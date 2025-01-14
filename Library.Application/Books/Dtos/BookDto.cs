namespace Library.Application.Books.Dtos;
public record BookDto(int Id,string Title, string Author, string Isbn, int PublishedYear, bool IsAvaliable);