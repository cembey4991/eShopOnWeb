using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.Web.ViewModels
{
    public class GetAllOrderViewModel
    {
        
    public string? Email{get;set;}
    public int OrderNumber { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public decimal Total { get; set; }
    public string? Status {get;set;}

    }
}
