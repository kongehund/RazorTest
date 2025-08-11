using RazorTest.Models;

namespace RazorTest.Services;

public interface IGameService
{
    IQueryable<Game> GetGames();
    Game? GetGame(int id);
    Game AddGame(string title, string platform, GameDeveloper dev, DateTime publishedDate);
    Game? UpdateGame(int id, string? title = null, string? platform = null, GameDeveloper? dev = null, DateTime? publishedDate = null);
    bool DeleteGame(int id);
}
