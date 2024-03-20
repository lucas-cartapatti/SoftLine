namespace Api.Models;

public class CustomerModel : BaseModel
{
    public string CompanyName { get; set; }
    public string TradeName { get; set; }  
    public string Document { get; set; }
    public string Location { get; set; }
    public bool Active { get; set; }
}