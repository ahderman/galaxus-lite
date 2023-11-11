namespace GalaxusWebApi.Models;

public class Product
{
    public uint Id { get; set; }
    public String? Name { get; set; }
    public String? Description { get; set; }
    public String? ImageUrl { get; set; }
    public String? SecretField { get; set; }
}
