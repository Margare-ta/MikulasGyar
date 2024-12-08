namespace MikulasGyar.EndPoints;

public static class PostMethods
{
    public static WebApplication PostFactoryItems(this WebApplication app)
    {

        app.MapPost("/toys", async (Toy toy) =>
        {

            using var db = new DatabaseContext();

            db.Toys.Add(toy);
            await db.SaveChangesAsync();

            return Results.Redirect("/toys");
        });



        return app;
    }

}
