using gamelib.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace gamelib.EndPoints.Consoles;

public class PlatformDelete
{
    public static string Template => "/platform/{id}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action([FromRoute] Guid id, ApplicationDbContext ctx)
    {
        var platform = ctx.Consoles.FirstOrDefault(c => c.Id == id);

        if (platform == null)
        {
            return Results.NotFound("Platform not found!");
        }

        ctx.Consoles.Remove(platform);
        ctx.SaveChanges();

        return Results.Ok();
    }
}
