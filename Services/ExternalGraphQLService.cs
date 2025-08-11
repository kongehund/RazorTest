using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;

namespace RazorTest.Services;

public class ExternalGraphQLService : IExternalGraphQLService, IDisposable
{
    private readonly GraphQLHttpClient _client;

    public ExternalGraphQLService(IConfiguration configuration)
    {
        var endpoint = configuration["GraphQL:Endpoint"] ?? throw new ArgumentException("GraphQL endpoint not configured");

        _client = new GraphQLHttpClient(endpoint, new SystemTextJsonSerializer());

        // Add authentication if needed
        var token = configuration["GraphQL:Token"];
        if (!string.IsNullOrEmpty(token))
        {
            _client.HttpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<T?> QueryAsync<T>(string query, object? variables = null)
    {
        var request = new GraphQLRequest
        {
            Query = query,
            Variables = variables
        };

        var response = await _client.SendQueryAsync<T>(request);

        if (response.Errors != null && response.Errors.Any())
        {
            throw new Exception($"GraphQL errors: {string.Join(", ", response.Errors.Select(e => e.Message))}");
        }

        return response.Data;
    }

    public async Task<T?> MutateAsync<T>(string mutation, object? variables = null)
    {
        var request = new GraphQLRequest
        {
            Query = mutation,
            Variables = variables
        };

        var response = await _client.SendMutationAsync<T>(request);

        if (response.Errors != null && response.Errors.Any())
        {
            throw new Exception($"GraphQL errors: {string.Join(", ", response.Errors.Select(e => e.Message))}");
        }

        return response.Data;
    }

    public void Dispose()
    {
        _client?.Dispose();
    }
}
