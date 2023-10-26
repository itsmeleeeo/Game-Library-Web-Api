using gamelib.Domain.Consoles;
using gamelib.Infra.Data;

namespace gamelib.EndPoints.Consoles;

public class PlatformPost
{
    public static string Template => "/platform";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action(PlatformRequest platformRequest, ApplicationDbContext ctx)
    {
        var platform = new Platform
        {
            Name = platformRequest.Name,
        };

        ctx.Consoles.Add(platform);
        ctx.SaveChanges();

        return Results.Created($"/platform/{platform.Id}", platform.Id);
    }
}
