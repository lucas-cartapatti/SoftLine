using Api.Domain;

namespace Api.Models;

public class ProductModel : BaseModel
{
    public string Description { get; set; }

    public string Code { get; set; }

    public decimal Price { get; set; }

    public decimal GrossWeight { get; set; }

    public decimal NetWeight { get; set; }

    public ProductModel()
    {
        this.Description = string.Empty;
        this.Code = string.Empty;
    }
}