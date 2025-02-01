namespace Library.Core.Common;
public class BooksErrors
{
    public static Error NotFound => new("BookNotFound", "Book not found");
    public static Error PublishedYearGreaterThanZero => new("PublishedYearGreaterThanZero", "Published Year must be greater than zero");
    public static Error TitleRequired => new("TitleRequired", "Title is required");
    public static Error AuthorRequired => new("AuthorRequired", "Author is required");
    public static Error IsbnRequired => new("IsbnRequired", "ISBN is required");
}
