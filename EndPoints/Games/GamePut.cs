using gamelib.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace gamelib.EndPoints.Games;

public class GamePut
{
    public static string Template => "/game/{id}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action([FromRoute] Guid id, GameRequest gameRequest, ApplicationDbContext ctx)
    {
        var games = ctx.Games.Where(c => c.Id == id).FirstOrDefault();

        games.Name = gameRequest.Name;
        games.Year = gameRequest.Year;
        games.Cover = gameRequest.Cover;

        ctx.SaveChanges();

        return Results.Ok();
    }
}
