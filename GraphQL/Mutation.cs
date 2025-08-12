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

    public Game AddGame(string title, string platform, int gameDevId, DateTime publishedDate, [Service] IGameService gameService)
    {
        return gameService.AddGame(title, platform, gameDevId, publishedDate);
    }

    public Game? UpdateGame(int id, [Service] IGameService gameService, [Service] IGameDeveloperService devService, string? title = null, string? platform = null, int? gameDevId = null, DateTime? publishedDate = null)
    {
        if (gameDevId != null && devService.GetGameDeveloper(gameDevId.Value) == null)
            throw new GraphQLException("Game Developer does not exist");

        return gameService.UpdateGame(id, title, platform, gameDevId, publishedDate);
    }

    public bool DeleteGame(int id, [Service] IGameService gameService)
    {
        return gameService.DeleteGame(id);
    }

    public GameDeveloper AddGameDeveloper(string name, DateTime founded, [Service] IGameDeveloperService gameDeveloperService)
    {
        return gameDeveloperService.AddGameDeveloper(name, founded);
    }

    public GameDeveloper? UpdateGameDeveloper(int id, [Service] IGameDeveloperService gameDeveloperService, DateTime? founded, string? name = null)
    {
        return gameDeveloperService.UpdateGameDeveloper(id, name, founded);
    }

    public bool DeleteGameDeveloper(int id, [Service] IGameDeveloperService gameDeveloperService)
    {
        return gameDeveloperService.DeleteGameDeveloper(id);
    }
}