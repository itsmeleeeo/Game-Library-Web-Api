using gamelib.Infra.Data;

namespace gamelib.EndPoints.Games;

public class GameGetAll
{
    public static string Template => "/games";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action(ApplicationDbContext ctx)
    {
        var games = ctx.Games.ToList();
        var response = games.Select(x => new GameResponse { Name = x.Name, ConsoleId = x.ConsoleId, Cover = x.Cover, Year = x.Year});

        return Results.Ok(games);
    }
}
