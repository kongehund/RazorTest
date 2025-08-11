using RazorTest.GraphQL;
using RazorTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register the book service as singleton to maintain state
builder.Services.AddSingleton<IBookService, BookService>();

// Add GraphQL services
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();

// Register the external GraphQL service
builder.Services.AddScoped<IExternalGraphQLService, ExternalGraphQLService>();

// Register the SWAPI service
builder.Services.AddScoped<ISwapiService, SwapiService>();

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

// Map GraphQL endpoint
app.MapGraphQL();

app.Run();
