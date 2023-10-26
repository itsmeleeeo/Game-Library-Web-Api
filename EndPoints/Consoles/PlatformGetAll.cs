using gamelib.Infra.Data;

namespace gamelib.EndPoints.Consoles;

public class PlatformGetAll
{
    public static string Template => "/platforms";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action(ApplicationDbContext ctx)
    {
        var platform = ctx.Consoles.ToList();
        var response = platform.Select(x => new PlatformResponse { Name = x.Name });

        return Results.Ok(platform);
    }
}
