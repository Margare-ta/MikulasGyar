namespace MikulasGyar.EndPoint;

public static class GetMethods
{
    public static WebApplication GetAllFactoryItems(this WebApplication app)
    {

        app.MapGet("/", () =>
        {
            string newToyData = "";
            using var db = new DatabaseContext();

            var toys = db.Toys
                        .ToList();

            foreach (var item in toys)
            {
                newToyData += item.ToString();
            }
            return newToyData;
        });

        app.MapGet("/toys", () =>
        {
            string newToyData = "";

            using var db = new DatabaseContext();

            var toys = db.Toys
                        .ToList();

            foreach (var item in toys)
            {
                newToyData += item.ToString();
            }

            return newToyData.ToString();

        });

        app.MapGet("/toys/{id}", (string id) =>
        {
            if (int.TryParse(id, out int desiredId))
            {
                string searchedToy = "";

                using var db = new DatabaseContext();

                var toy = db.Toys
                           .Where(item => item.Id == desiredId);

                if (toy == null)
                {
                    return "Toy with ID" + id + "not found.";
                }

                foreach (var item in toy)
                {
                    searchedToy = item.ToString();
                }

                return searchedToy;
            }
            throw new FormatException(id);
        });

        return app;
    }
}
