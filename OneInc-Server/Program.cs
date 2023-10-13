using OneInc_Server.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials());
});

var app = builder.Build();
app.UseCors("AllowAll");

app.MapGet("/", () => "Hello World!");
app.MapHub<EncodingHub>("/encodingHub");

app.Run();
