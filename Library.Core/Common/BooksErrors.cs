namespace Library.Core.Common;
public class BooksErrors
{
    public static Error NotFound => new("BookNotFound", "Book not found");
    public static Error PublishedYearGreaterThanZero => new("PublishedYearGreaterThanZero", "Published Year must be greater than zero");
}
