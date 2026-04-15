using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Models;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGameById";

    private static readonly List<GameDto> games = [
        new (1, "Street Fighter 2", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
        new (2, "The Legend of Zelda: Ocarina of Time", "Action-Adventure", 29.99M, new DateOnly(1998, 11, 21)),
        new (3, "Super Mario 64", "Platformer", 24.99M, new DateOnly(1996, 6, 23)),
    ];

    public static void MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");

        // GET /games endpoint that will return all games
        group.MapGet("/", () => games);

        // GET /games/{id} endpoint that will return a single game by id
        group.MapGet("/{id}", (int id) =>
        {
            var game = games.FirstOrDefault(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        }).WithName(GetGameEndpointName);

        // POST /games endpoint that will add a new game to the list
        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
           Game game = new () {
                Name = newGame.Name,
                GenreId = newGame.GenreId,
                Price = newGame.Price,
                ReleaseDate = newGame.ReleaseDate
            };

            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            GameDetailsDto gameDto = new (
                game.Id,
                game.Name,
                game.GenreId,
                game.Price,
                game.ReleaseDate
            );
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = gameDto.Id }, gameDto);
        });

        // PUT /games/{id} endpoint that will update a game by id
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                Id: id,
                Name: updatedGame.Name,
                Genre: updatedGame.Genre,
                Price: updatedGame.Price,
                ReleaseDate: updatedGame.ReleaseDate
            );
            return Results.NoContent();
        });

        // DELETE /games/{id} endpoint that will delete a game by id
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });
    }
}
