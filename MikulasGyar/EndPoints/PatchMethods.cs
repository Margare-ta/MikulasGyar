using System.Text.Json;

namespace MikulasGyar.EndPoints;

public static class PatchMethods
{
    public static WebApplication PatchFactoryItems(this WebApplication app)
    {
        app.MapPatch("/toys/{id}", (string id, JsonElement data) =>
        {
            if (int.TryParse(id, out int desiredId))
            {
                string searchedToy = "";


                using var db = new DatabaseContext();

                var toy = db.Toys
                            .Where(item => item.Id == desiredId);

                string newData = data.ToString();
                string newName = "";
                string newMaterial = "";
                string newWeight = "";

                string[] datas = newData.Split('\"');


                if (datas.Contains("weight"))
                {
                    for (int i = 0; i < datas.Length; i++)
                    {
                        if (datas[i] == ": ")
                        {
                            newWeight = datas[i + 1];
                        }
                        else
                        {
                            return "invalid weight";
                        }
                    }
                }
                else if (datas.Contains("name"))
                {
                    for (int i = 0; i < datas.Length; i++)
                    {
                        if (datas[i] == ": ")
                        {
                            newName = datas[i + 1];
                        }
                        else
                        {
                            return "invalid name";
                        }
                    }
                }
                else if (datas.Contains("material"))
                {
                    if (datas.Contains("wood") || datas.Contains("plastic") || datas.Contains("metal") || datas.Contains("other"))
                    {
                        for (int i = 0; i < datas.Length; i++)
                        {
                            if (datas[i] == ": ")
                            {
                                newMaterial = datas[i + 1];
                            }
                            else
                            {
                                return "invalid material";
                            }
                        }
                    }
                    else
                    {
                        return "wrong material!";
                    }
                }
                else
                {
                    return "wrong data";
                }

                if (newWeight != "")
                {
                    foreach (var item in toy)
                    {
                        item.Weight = newWeight;
                        db.Update(item);
                        searchedToy = item.ToString();
                    }
                }
                else if (newName != "")
                {
                    foreach (var item in toy)
                    {
                        item.Name = newName;
                        db.Update(item);
                        searchedToy = item.ToString();
                    }
                }
                else if (newMaterial != "")
                {
                    foreach (var item in toy)
                    {
                        item.Material = newMaterial;
                        db.Update(item);
                        searchedToy = item.ToString();

                    }
                }

                db.SaveChanges();
                return searchedToy.ToString();
            }
            return "wrong id";
        });



        return app;
    }
}
