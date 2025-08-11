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

    public IQueryable<GameDeveloper> GetGameDevelopers([Service] IGameDeveloperService gameDeveloperService)
    {
        return gameDeveloperService.GetGameDevelopers();
    }

    public GameDeveloper? GetGameDeveloper(int id, [Service] IGameDeveloperService gameDeveloperService)
    {
        return gameDeveloperService.GetGameDeveloper(id);
    }

    public IQueryable<Game> GetGames([Service] IGameService gameService)
    {
        return gameService.GetGames();
    }

    public Game? GetGame(int id, [Service] IGameService gameService)
    {
        return gameService.GetGame(id);
    }
}

