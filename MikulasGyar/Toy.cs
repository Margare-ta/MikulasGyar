namespace MikulasGyar;

public class Toy
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Material { get; set; }
    public string Weight { get; set; }

    public List<Kid> Kids { get; set; }
}
