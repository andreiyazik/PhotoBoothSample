namespace PhotoBooth.Data.Models;

public class Package
{
    public int Id { get; set; }
    public PackageType Type { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
