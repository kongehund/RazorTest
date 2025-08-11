using RazorTest.Models.StarWars;

namespace RazorTest.Services;

public interface ISwapiService
{
    Task<List<Film>> GetAllFilmsAsync();
    Task<Film?> GetFilmAsync(string filmId);
    Task<List<Person>> GetAllPeopleAsync();
    Task<Person?> GetPersonAsync(string personId);
}
