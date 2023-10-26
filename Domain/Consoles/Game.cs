namespace gamelib.Domain.Consoles
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Cover { get; set; }
        public Platform Console { get; set; }
        public Guid ConsoleId { get; set; }
    }
}
