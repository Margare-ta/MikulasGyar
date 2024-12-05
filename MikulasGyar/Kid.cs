namespace MikulasGyar;

public class Kid
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public bool WasGood { get; set; }
    public ICollection<Toy> Toys { get; set; }
}
