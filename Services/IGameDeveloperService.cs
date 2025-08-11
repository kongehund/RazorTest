using RazorTest.Models;

namespace RazorTest.Services;

public interface IGameDeveloperService
{
    IQueryable<GameDeveloper> GetGameDevelopers();
    GameDeveloper? GetGameDeveloper(int id);
    GameDeveloper AddGameDeveloper(string name, DateTime founded);
    GameDeveloper? UpdateGameDeveloper(int id, string? name = null, DateTime? founded = null);
    bool DeleteGameDeveloper(int id);
}
