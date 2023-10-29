using gamelib.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace gamelib.EndPoints.Games;

public class GameDelete
{

    public static string Template => "/game/{id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action([FromRoute] Guid id, ApplicationDbContext ctx)
    {
        var game = ctx.Games.FirstOrDefault(c => c.Id == id);

        if(game == null)
        {
            return Results.NotFound("Game not found!");
        }

        ctx.Games.Remove(game);
        ctx.SaveChanges();

        return Results.Ok();
    }
}
