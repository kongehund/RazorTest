using RazorTest.Models;

namespace RazorTest.Services;

public class GameDeveloperService : IGameDeveloperService
{
    private static readonly List<GameDeveloper> _gameDevs = new()
        {
            new GameDeveloper {Id = 1, Name = "Nintendo EPD", Founded = new DateTime(2015, 9, 16)},
            new GameDeveloper {Id = 2, Name = "Santa Monica Studio", Founded = new DateTime(1999, 1, 1)},
            new GameDeveloper {Id = 3, Name = "343 Industries", Founded = new DateTime(2007, 7, 21)},
            new GameDeveloper {Id = 4, Name = "ConcernedApe", Founded = new DateTime(2012, 1, 1)}
        };

    public GameDeveloper AddGameDeveloper(string name, DateTime founded)
    {
        var gameDev = new GameDeveloper() { Id = _gameDevs.Count, Name = name, Founded = founded };
        _gameDevs.Add(gameDev);

        return gameDev;
    }

    public bool DeleteGameDeveloper(int id)
    {
        var dev = GetGameDeveloper(id);

        if (dev == null) return false;

        _gameDevs.Remove(dev);
        return true;
    }

    public GameDeveloper? GetGameDeveloper(int id)
    {
        return _gameDevs.FirstOrDefault(g => g.Id == id);
    }

    public IQueryable<GameDeveloper> GetGameDevelopers()
    {
        return _gameDevs.AsQueryable();
    }

    public GameDeveloper? UpdateGameDeveloper(int id, string? name = null, DateTime? founded = null)
    {
        var dev = GetGameDeveloper(id);

        if (dev == null) return null;
        if (name != null) dev.Name = name;
        if (founded != null) dev.Founded = founded.Value;

        return dev;
    }
}
