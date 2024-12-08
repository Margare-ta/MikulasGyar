namespace MikulasGyar.EndPoints;

public static class PutMethods
{
    public static WebApplication PutFactoryItems(this WebApplication app)
    {
        app.MapPut("/children/{kidId}/toys/{toyId}", (string kidId, string toyId) =>
        {
            string returnAnswer = "";
            if (int.TryParse(kidId, out int desiredKidId) && int.TryParse(toyId, out int desiredToyId))
            {
                using var db = new DatabaseContext();

                var kid = db.Kids
                           .Where(item => item.Id == desiredKidId);

                if (kid is not null)
                {
                    var toy = db.Toys
                            .Where(item => item.Id == desiredToyId);

                    if (toy is not null)
                    {
                        foreach (var item in toy)
                        {
                            foreach (var item2 in kid)
                            {
                                item.Kids.Add(item2);
                                returnAnswer += "success";
                            }
                        }
                        db.SaveChanges();
                        return returnAnswer;
                    }
                    else
                    {
                        return "toy id is invalid";
                    }
                }
                else
                {
                    return "kid id is invalid";
                }
            }
            else
            {
                return "Id is ivalid";
            }
            return "error";

        });
        return app;
    }
}
