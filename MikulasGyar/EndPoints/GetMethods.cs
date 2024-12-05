namespace MikulasGyar.EndPoint;

public static class GetMethods
{
    public static WebApplication GetAllFactoryItems(this WebApplication app)
    {
        string toyData = "";

        app.MapGet("/seedData", () =>
        {
            using var db = new DatabaseContext();

            var toy1 = new Toy() { Material = "wood", Name = "Diótörő", Weight = "1" };
            var toy2 = new Toy() { Material = "metal", Name = "Bicikli", Weight = "3" };
            var toy3 = new Toy() { Material = "plastic", Name = "Lepkefogó", Weight = "0,2" };
            db.Toys.Add(toy1);
            db.Toys.Add(toy2);
            db.Toys.Add(toy3);

            var kid1 = new Kid() { Name = "Sáros Cucu", WasGood = false, Address = "1122 Budapest Szép utca 11" };
            var kid2 = new Kid() { Name = "Nagy Cucu", WasGood = true, Address = "1002 Cegléd Csúnya utca 132" };
            var kid3 = new Kid() { Name = "Kis Cucu", WasGood = false, Address = "2222 Kecskemét Károly körút 3" };
            db.Kids.Add(kid1);
            db.Kids.Add(kid2);
            db.Kids.Add(kid3);

            db.SaveChanges();

            return "Data succesfully added";
        });

        app.MapGet("/", () =>
        {
            using var db = new DatabaseContext();

            var toys = db.Toys
                        .ToList();

            foreach (var item in toys)
            {
                toyData += item.ToString();
            }
            return toyData;
        });

        app.MapGet("/toys", () => toyData);

        app.MapGet("/toys/{id}", (string id) =>
        {
            if (int.TryParse(id, out int desiredId))
            {
                string searchedToy = "";
                using var db = new DatabaseContext();

                if (desiredId > Convert.ToInt32(db.Toys.Count()))
                {
                    throw new InvalidOperationException("Toy not found");
                }

                var toy = db.Toys
                            .Where(item => item.Id == desiredId);
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
