using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new (1, "Street Fighter 2", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
    new (2, "The Legend of Zelda: Ocarina of Time", "Action-Adventure", 29.99M, new DateOnly(1998, 11, 21)),
    new (3, "Super Mario 64", "Platformer", 24.99M, new DateOnly(1996, 6, 23)),
];

// GET /games endpoint that will return all games
app.MapGet("/games", () => games);

// GET /games/{id} endpoint that will return a single game by id
app.MapGet("/games/{id}", (int id) => games.FirstOrDefault(game => game.Id == id));

app.Run();
