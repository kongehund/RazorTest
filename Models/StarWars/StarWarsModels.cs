namespace RazorTest.Models.StarWars;

public class Film
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int EpisodeID { get; set; }
    public string Director { get; set; } = string.Empty;
    public string ReleaseDate { get; set; } = string.Empty;
    public string OpeningCrawl { get; set; } = string.Empty;
}

public class Person
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BirthYear { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Height { get; set; } = string.Empty;
    public string Mass { get; set; } = string.Empty;
    public string EyeColor { get; set; } = string.Empty;
    public string HairColor { get; set; } = string.Empty;
    public string SkinColor { get; set; } = string.Empty;
    public Planet? Homeworld { get; set; }
}

public class Planet
{
    public string Name { get; set; } = string.Empty;
    public string Climate { get; set; } = string.Empty;
    public string Terrain { get; set; } = string.Empty;
}