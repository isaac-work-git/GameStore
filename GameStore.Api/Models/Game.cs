namespace GameStore.Api.Models;

public class Game
{
    public int Id { get; set; }

    // Strings must be initialized to avoid null reference exceptions when deserializing JSON into this class
    public required string Name { get; set; } = string.Empty;

    public Genre? Genre { get; set; }

    public int GenreId { get; set; }
    
    public decimal Price { get; set; }
    
    public DateOnly ReleaseDate { get; set; }
}
