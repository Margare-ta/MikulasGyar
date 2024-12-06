namespace MikulasGyar.EndPoint;

public static class DeleteMethods
{
    public static WebApplication DeleteFactoryItems(this WebApplication app)
    {
        app.MapDelete("/toys/{id}", (string id) =>
        {
            if (int.TryParse(id, out int desiredId))
            {
                Toy searchedToy = new Toy();

                //Mi van, ha már törölték azt a toyt?

                using var db = new DatabaseContext();
                var toy = db.Toys
                            .Where(item => item.Id == desiredId);

                foreach (var item in toy)
                {
                    searchedToy = item;
                }

                db.Toys.Remove(searchedToy);
                db.SaveChanges();

                return searchedToy.ToString() + "is removed";
            }
            throw new FormatException(id);
        });
        return app;
    }
}
