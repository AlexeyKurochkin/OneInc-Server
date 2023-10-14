using OneInc_Server.Hubs;
using OneInc_Server.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebClient",
        builder => builder.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:5173")
            .AllowCredentials());
});
builder.Services.AddScoped<IStringEncoderManager, StringEncoderManager>();
builder.Services.AddScoped<IStringEncoder, StringEncoder>();

var app = builder.Build();
app.UseCors("AllowWebClient");

app.MapGet("/", () => "Hello World!");
app.MapHub<EncodingHub>("/hubs/encodingHub");

app.Run();
