using RazorTest.Models.StarWars;

namespace RazorTest.Services
{
    public class SwapiService : ISwapiService
    {
        private readonly IExternalGraphQLService _graphQLService;

        public SwapiService(IExternalGraphQLService graphQLService)
        {
            _graphQLService = graphQLService;
        }

        public async Task<List<Film>> GetAllFilmsAsync()
        {
            var query = @"
            {
                allFilms {
                    films {
                        title
                        episodeID
                    }
                }
            }";

            var response = await _graphQLService.QueryAsync<dynamic>(query);
            // For now, just return empty list to test connection
            return new List<Film>();
        }

        public async Task<Film?> GetFilmAsync(string id)
        {
            var query = @"
                query($filmId: ID!) {
                    film(id: $filmId) {
                        id
                        title
                        episodeID
                        director
                        releaseDate
                        openingCrawl
                    }
                }";

            var variables = new { filmId = id };
            var response = await _graphQLService.QueryAsync<FilmResponse>(query, variables);
            return response?.Film;
        }

        public async Task<List<Person>> GetAllPeopleAsync()
        {
            var query = @"
                query {
                    allPeople {
                        people {
                            id
                            name
                            birthYear
                            gender
                            height
                            mass
                            eyeColor
                            hairColor
                            skinColor
                            homeworld {
                                name
                                climate
                                terrain
                            }
                        }
                    }
                }";

            var response = await _graphQLService.QueryAsync<PeopleResponse>(query);
            return response?.AllPeople?.People ?? new List<Person>();
        }

        public async Task<Person?> GetPersonAsync(string id)
        {
            var query = @"
                query($personId: ID!) {
                    person(id: $personId) {
                        id
                        name
                        birthYear
                        gender
                        height
                        mass
                        eyeColor
                        hairColor
                        skinColor
                        homeworld {
                            name
                            climate
                            terrain
                        }
                    }
                }";

            var variables = new { personId = id };
            var response = await _graphQLService.QueryAsync<PersonResponse>(query, variables);
            return response?.Person;
        }
    }

    // Response wrapper classes for GraphQL
    public class FilmsResponse
    {
        public AllFilmsData AllFilms { get; set; } = new();
    }

    public class AllFilmsData
    {
        public List<Film> Films { get; set; } = new();
    }

    public class FilmResponse
    {
        public Film? Film { get; set; }
    }

    public class PeopleResponse
    {
        public AllPeopleData AllPeople { get; set; } = new();
    }

    public class AllPeopleData
    {
        public List<Person> People { get; set; } = new();
    }

    public class PersonResponse
    {
        public Person? Person { get; set; }
    }
}