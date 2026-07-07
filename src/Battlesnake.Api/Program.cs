using System.Text.Json;
using System.Text.Json.Serialization;
using Battlesnake.Api.Endpoints;
using Battlesnake.Application;
using Battlesnake.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Composition root: wire up the application and infrastructure layers.
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Enums serialize as kebab-case strings to match the Battlesnake API
// (e.g., Direction.Up -> "up", BattlesnakeHead.TransRightsScarf -> "trans-rights-scarf").
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(
        new JsonStringEnumConverter(JsonNamingPolicy.KebabCaseLower));
});

var app = builder.Build();

app.UseHttpsRedirection();
app.MapSnakeEndpoints();

app.Run();