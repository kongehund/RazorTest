using RazorTest.GraphQL;
using RazorTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register the services as singleton to maintain state
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IGameDeveloperService, GameDeveloperService>();
builder.Services.AddSingleton<IGameService, GameService>();


// Add GraphQL services
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Map GraphQL endpoint. This is what makes Nitro available with /graphql/
app.MapGraphQL();

app.Run();
