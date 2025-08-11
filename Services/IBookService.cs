using RazorTest.Models;

namespace RazorTest.Services;

public interface IBookService
{
    IQueryable<Book> GetBooks();
    Book? GetBook(int id);
    Book AddBook(string title, string author, DateTime publishedDate);
    Book? UpdateBook(int id, string? title = null, string? author = null, DateTime? publishedDate = null);
    bool DeleteBook(int id);
}