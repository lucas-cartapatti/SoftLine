using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain;

public class Customer : EntityBase<Customer>
{
    [Column(nameof(CompanyName))]
    [MaxLength(150)]
    public string CompanyName { get; set; }
    
    [Column(nameof(TradeName))]
    [MaxLength(25)]
    public string TradeName { get; set; }
    
    [Column(nameof(Document))]
    [MaxLength(20)]
    public string Document { get; set; }
    
    [Column(nameof(Location))]
    [MaxLength(300)]
    public string Location { get; set; }
    
    [Column(nameof(Active))]
    public bool Active { get; set; }

    public Customer()
    {
        this.CompanyName = string.Empty;
        this.TradeName = string.Empty;
        this.Document = string.Empty;
        this.Location = string.Empty;
        this.Active = false;
    }
}