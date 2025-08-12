using RazorTest.Services;

namespace RazorTest.Models;


public class Game
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Platform { get; set; } = string.Empty;
    public int DeveloperId { get; set; }

    public DateTime PublishedDate { get; set; }

    public GameDeveloper? GetDeveloper([Service] IGameDeveloperService devService)
        => devService.GetGameDeveloper(DeveloperId);

}
