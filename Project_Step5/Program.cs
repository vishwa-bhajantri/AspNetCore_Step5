using Project_Step5.Interfaces;
using Project_Step5.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseHttpsRedirection();

//Logging Mechanism
app.Use((HttpContext context, RequestDelegate next) =>
{
    string? userName = context.Request.Headers["UserName"];

    Console.WriteLine(userName);

    return next(context);
});

//Authentication
app.Use((HttpContext context, RequestDelegate next) =>
{
    string? userName = context.Request.Headers["UserName"];

    if(userName != "Vishwa")
    {
        context.Response.StatusCode = 401;
        return context.Response.WriteAsync("Unauthorized User");
    }

    else
    {
        //context.Response.StatusCode = 200;
        //return context.Response.WriteAsync("Authorized user");

        return next(context);
    }
});


//Authorization
app.Use((HttpContext context, RequestDelegate next) =>
{
    string? userName = context.Request.Headers["UserName"];
    string? UserApiKey = context.Request.Headers["UserApiKey"];

    if (userName == "Vishwa" && UserApiKey == "6789")
    {

        return next(context);
    }

    else
    {
        context.Response.StatusCode = 401;
        return context.Response.WriteAsync("Unauthorized User");
    }
});

app.MapControllers();

app.Run();
