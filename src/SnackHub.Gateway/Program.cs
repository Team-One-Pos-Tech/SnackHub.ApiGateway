var builder = WebApplication.CreateBuilder(args);

const string reverseProxySection = "ReverseProxy";

// Add services to the container.
builder
    .Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection(reverseProxySection));

var app = builder.Build();
app.MapReverseProxy();
// Configure the HTTP request pipeline.
if (bool.TryParse(builder.Configuration.GetSection("https").Value, out var result) && result)
    app.UseHttpsRedirection();
app.Run();
