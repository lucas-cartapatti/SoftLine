using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain;

public class Product : EntityBase<Product>
{
    [Column(nameof(Description))]
    [MaxLength(150)]
    public string Description { get; set; }

    [Column(nameof(Code))]
    [MaxLength(25)]
    public string Code { get; set; }
    
    [Column(nameof(Price), TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    [Column(nameof(GrossWeight), TypeName ="decimal(18,3)")]
    public decimal GrossWeight { get; set; }
    
    [Column(nameof(NetWeight), TypeName ="decimal(18,3)")]
    public decimal NetWeight { get; set; }

    public Product()
    {
        this.Description = string.Empty;
        this.Code = string.Empty;
    }

}