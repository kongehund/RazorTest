using RazorTest.Models;

namespace RazorTest.Services;

public class BookService : IBookService
{
    private static readonly List<Book> _books = new()
        {
            new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublishedDate = new DateTime(1925, 4, 10) },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublishedDate = new DateTime(1960, 7, 11) }
        };

    public IQueryable<Book> GetBooks() => _books.AsQueryable();

    public Book? GetBook(int id) => _books.FirstOrDefault(b => b.Id == id);

    public Book AddBook(string title, string author, DateTime publishedDate)
    {
        var book = new Book
        {
            Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1,
            Title = title,
            Author = author,
            PublishedDate = publishedDate
        };

        _books.Add(book);
        return book;
    }

    public Book? UpdateBook(int id, string? title = null, string? author = null, DateTime? publishedDate = null)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null) return null;

        if (!string.IsNullOrEmpty(title)) book.Title = title;
        if (!string.IsNullOrEmpty(author)) book.Author = author;
        if (publishedDate.HasValue) book.PublishedDate = publishedDate.Value;

        return book;
    }

    public bool DeleteBook(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null) return false;

        _books.Remove(book);
        return true;
    }
}