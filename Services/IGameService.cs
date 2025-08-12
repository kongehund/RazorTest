using RazorTest.Models;

namespace RazorTest.Services;

public interface IGameService
{
    IQueryable<Game> GetGames();
    Game? GetGame(int id);
    Game AddGame(string title, string platform, int gameDevId, DateTime publishedDate);
    Game? UpdateGame(int id, string? title = null, string? platform = null, int? gameDevId = null, DateTime? publishedDate = null);
    bool DeleteGame(int id);
}
