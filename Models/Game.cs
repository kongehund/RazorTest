namespace RazorTest.Models;

public class Game
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Platform { get; set; } = string.Empty;
    public GameDeveloper Developer { get; set; } = new GameDeveloper {};

    public DateTime PublishedDate { get; set; }
}
