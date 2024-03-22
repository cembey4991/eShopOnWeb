using System.ComponentModel.DataAnnotations;
namespace Microsoft.eShopWeb.ApplicationCore.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Pending")]
        Pending = 0,
        [Display(Name = "Delivered")]
        Delivered = 1,
        [Display(Name = "Approved")]
        Approved = 2,
        [Display(Name = "OutForDelivery")]
        OutForDelivery = 3,
    }
}
