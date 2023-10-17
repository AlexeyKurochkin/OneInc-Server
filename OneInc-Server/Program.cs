using OneInc_Server.Hubs;
using OneInc_Server.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var allowedWebClientOrigin = Environment.GetEnvironmentVariable("ALLOWED_WEBCLIENT_ORIGINS") ??
                             builder.Configuration.GetSection("AllowedOrigins")["WebClient"];
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebClient",
        builder => builder.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins(allowedWebClientOrigin)
            .AllowCredentials());
});
builder.Services.AddScoped<IStringEncoderManager, StringEncoderManager>();
builder.Services.AddScoped<IStringEncoder, StringEncoder>();

var app = builder.Build();
app.UseCors("AllowWebClient");

app.MapGet("/", () => "Hello World!");
app.MapHub<EncodingHub>("/hubs/encodingHub");

app.Run();