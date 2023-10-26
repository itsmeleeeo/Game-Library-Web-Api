using gamelib.Domain.Consoles;
using gamelib.Infra.Data;

namespace gamelib.EndPoints.Games;

public class GamePost
{
    public static string Template => "/game";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action(GameRequest gameRequest, ApplicationDbContext ctx)
    {
        var game = new Game
        {
            Name = gameRequest.Name,
            Year = gameRequest.Year,
            Cover = gameRequest.Cover,
            ConsoleId = gameRequest.ConsoleId
        };

        ctx.Games.Add(game);
        ctx.SaveChanges();

        return Results.Created($"/game/{game.Id}", game.Id);
    }

}
