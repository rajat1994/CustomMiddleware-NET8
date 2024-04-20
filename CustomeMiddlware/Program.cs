using CustomMiddlware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddlware>();

var app = builder.Build();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Welcome to Middleware1\n");
    await next(context);
});

app.UseMiddleware<MyCustomMiddlware>();
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Welcome to CustomMiddlware project\n");
});


app.Run();
