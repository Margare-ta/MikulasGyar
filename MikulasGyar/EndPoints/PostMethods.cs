using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MikulasGyar.EndPoints;

public static class PostMethods
{
    public static WebApplication PostFactoryItems(this WebApplication app)
    {

        app.MapPost("/toys", ([FromBody] string givenNewToy) =>
        {

            var newToyData = JsonSerializer.Serialize<string, object>(givenNewToy);

            string newName = newToyData["name"].ToString();
            string newMaterial = newToyData["material"].ToString();
            string newWeight = newToyData["weight"].ToString().Replace(".", ",");

            var newToy = new Toy() { Material = newMaterial, Name = newName, Weight = newWeight };

            using var db = new DatabaseContext();

            db.Toys.Add(newToy);
            db.SaveChanges();

            return Results.Redirect("/toys");

        });

        return app;
    }

    public static bool IsValidJson(string jsonString)
    {
        try
        {
            JsonDocument.Parse(jsonString);
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
        catch (ArgumentNullException)
        {
            return false;
        }
    }
}
