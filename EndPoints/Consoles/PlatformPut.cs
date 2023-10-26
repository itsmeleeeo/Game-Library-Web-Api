using gamelib.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace gamelib.EndPoints.Consoles;

public class PlatformPut
{
    public static string Template => "/platform/{id}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action([FromRoute] Guid id, PlatformRequest platformRequest, ApplicationDbContext ctx)
    {
        var platform = ctx.Consoles.Where(c => c.Id == id).FirstOrDefault();

        platform.Name = platformRequest.Name;

        ctx.SaveChanges();

        return Results.Ok();
    }
}
