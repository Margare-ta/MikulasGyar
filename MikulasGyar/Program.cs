using MikulasGyar.EndPoint;
using MikulasGyar.EndPoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
{
    app.CreateFactoryItems();
    app.GetAllFactoryItems();
    app.DeleteFactoryItems();
    app.PostFactoryItems();
    app.PatchFactoryItems();
    app.PutFactoryItems();
}

app.Run();
