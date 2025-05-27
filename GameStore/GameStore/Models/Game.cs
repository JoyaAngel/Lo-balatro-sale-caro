namespace GameStore.Models
{
    public class Game
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Genre { get; set; }
        public required string Platform { get; set; }
        public required int Stock { get; set; }
        public required Decimal Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
