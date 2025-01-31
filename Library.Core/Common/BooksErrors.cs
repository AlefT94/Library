namespace Library.Core.Common;
public class BooksErrors
{
    public static Error NotFound => new("BookNotFound", "Book not found");
}
