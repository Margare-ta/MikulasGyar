using MikulasGyar.EndPoint;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
{
    app.GetAllFactoryItems();
}

app.Run();
