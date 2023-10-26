using gamelib.EndPoints.Consoles;
using gamelib.EndPoints.Games;
using gamelib.Infra.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionString:GameLib"]);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//POST
app.MapMethods(PlatformPost.Template, PlatformPost.Methods, PlatformPost.Handler);
app.MapMethods(GamePost.Template, GamePost.Methods, GamePost.Handler);

//GET
app.MapMethods(PlatformGetAll.Template, PlatformGetAll.Methods, PlatformGetAll.Handler);
app.MapMethods(GameGetAll.Template, GameGetAll.Methods, GameGetAll.Handler);

//PUT
app.MapMethods(PlatformPut.Template, PlatformPut.Methods, PlatformPut.Handler);
app.MapMethods(GamePut.Template, GamePut.Methods, GamePut.Handler);

//DELETE

app.Run();