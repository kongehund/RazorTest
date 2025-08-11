using RazorTest.Models;
using RazorTest.Services;

namespace RazorTest.GraphQL;

public class Query
{
    public IQueryable<Book> GetBooks([Service] IBookService bookService)
    {
        return bookService.GetBooks();
    }

    public Book? GetBook(int id, [Service] IBookService bookService)
    {
        return bookService.GetBook(id);
    }
}

