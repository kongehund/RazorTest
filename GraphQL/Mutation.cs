using RazorTest.Models;
using RazorTest.Services;

namespace RazorTest.GraphQL;

public class Mutation
{
    public Book AddBook(string title, string author, DateTime publishedDate, [Service] IBookService bookService)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new GraphQLException("Title cannot be empty");

        if (string.IsNullOrWhiteSpace(author))
            throw new GraphQLException("Author cannot be empty");

        return bookService.AddBook(title, author, publishedDate);
    }

    public Book? UpdateBook(int id, [Service] IBookService bookService, string? title = null, string? author = null, DateTime? publishedDate = null)
    {
        return bookService.UpdateBook(id, title, author, publishedDate);
    }

    public bool DeleteBook(int id, [Service] IBookService bookService)
    {
        return bookService.DeleteBook(id);
    }
}