var builder = WebApplication.CreateBuilder(args);

const string reverseProxySection = "ReverseProxy";

// Add services to the container.
builder
    .Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection(reverseProxySection));

var app = builder.Build();
app.MapReverseProxy();
app.UseHttpsRedirection();
app.Run();
