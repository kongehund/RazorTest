using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorTest.Models.StarWars;
using RazorTest.Services;

namespace RazorTest.Pages
{
    public class StarWarsModel : PageModel
    {
        private readonly ISwapiService _swapiService;

        public StarWarsModel(ISwapiService swapiService)
        {
            _swapiService = swapiService;
        }

        public List<Film> Films { get; set; } = new();
        public List<Person> People { get; set; } = new();
        public Film? SelectedFilm { get; set; }
        public Person? SelectedPerson { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FilmId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? PersonId { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                // Load films and people
                var filmsTask = _swapiService.GetAllFilmsAsync();
                var peopleTask = _swapiService.GetAllPeopleAsync();

                await Task.WhenAll(filmsTask, peopleTask);

                Films = filmsTask.Result;
                People = peopleTask.Result;

                // Load specific film or person if ID is provided
                if (!string.IsNullOrEmpty(FilmId))
                {
                    SelectedFilm = await _swapiService.GetFilmAsync(FilmId);
                }

                if (!string.IsNullOrEmpty(PersonId))
                {
                    SelectedPerson = await _swapiService.GetPersonAsync(PersonId);
                }
            }
            catch (Exception ex)
            {
                // Handle errors gracefully
                TempData["Error"] = $"Error loading Star Wars data: {ex.Message}";
            }
        }
    }
}
