using gamelib.Domain.Consoles;

namespace gamelib.EndPoints.Games;

public class GameResponse
{
    public string Name { get; set; }
    public int Year { get; set; }
    public string Cover { get; set; }
    public Guid ConsoleId { get; set; }
}