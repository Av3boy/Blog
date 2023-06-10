using Blog.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterServices();

var app = builder.Build();
app.Configure();

app.Run();