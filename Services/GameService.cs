using RazorTest.Models;

namespace RazorTest.Services;

public class GameService : IGameService
{
    private static readonly List<Game> _games = new()
        {
            new Game { 
                Id = 1, 
                Title = "The Legend of Zelda: Breath of the Wild", 
                Platform = "Nintendo Switch", 
                DeveloperId = 1,
                PublishedDate = new DateTime(2017, 3, 3) 
            },
            new Game {
                Id = 2,
                Title = "God of War",
                Platform = "Playstation 4",
                DeveloperId = 2,
                PublishedDate = new DateTime(2018, 4, 20)
            },
            new Game {
                Id = 3,
                Title = "Halo Infinite",
                Platform = "Xbox Series X",
                DeveloperId = 3,
                PublishedDate = new DateTime(2021, 12, 8)
            },
            new Game {
                Id = 4,
                Title = "Stardew Valley",
                Platform = "PC",
                DeveloperId = 4,
                PublishedDate = new DateTime(2016, 2, 26)
            },
            new Game {
                Id = 5,
                Title = "Super Mario Odyssey",
                Platform = "Nintendo Switch",
                DeveloperId = 1,
                PublishedDate = new DateTime(2017, 10, 27)
            },
        };

    public Game AddGame(string title, string platform, int gameDevId, DateTime publishedDate)
    {
        var game = new Game { Id = _games.Count, Title = title, Platform = platform, DeveloperId = gameDevId, PublishedDate = publishedDate };
        
        _games.Add(game);
        return game;
    }

    public bool DeleteGame(int id)
    {
        var game = GetGame(id);

        if (game == null) return false;

        _games.Remove(game);
        return true;
    }

    public Game? GetGame(int id)
    {
        return _games.FirstOrDefault(g => g.Id == id);
    }

    public IQueryable<Game> GetGames()
    {
        return _games.AsQueryable();
    }

    public Game? UpdateGame(int id, string? title = null, string? platform = null, int? gameDevId = null, DateTime? publishedDate = null)
    {
        var game = GetGame(id);

        if (game == null) return null;
        if (title != null) game.Title = title;
        if (platform != null) game.Platform = platform;
        if (gameDevId != null) game.DeveloperId = gameDevId.Value;
        if (publishedDate != null) game.PublishedDate = publishedDate.Value;

        return game;
    }
}
