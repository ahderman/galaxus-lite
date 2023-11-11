namespace GalaxusWebApi.Models;

public class ProductDTO
{
    public uint Id { get; set; }
    public String? Name { get; set; }
    public String? Description { get; set; }
    public String? ImageUrl { get; set; }
    public static ProductDTO FromProduct(Product product)
    {
        return new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl
        };
    }
}
