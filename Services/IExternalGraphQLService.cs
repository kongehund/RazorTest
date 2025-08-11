namespace RazorTest.Services;

public interface IExternalGraphQLService
{
    Task<T?> QueryAsync<T>(string query, object? variables = null);
    Task<T?> MutateAsync<T>(string mutation, object? variables = null);
}
