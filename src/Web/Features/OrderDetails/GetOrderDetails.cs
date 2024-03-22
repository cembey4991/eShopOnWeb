using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.OrderDetails;

public class GetOrderDetails : IRequest<OrderDetailViewModel>
{
    public int OrderId { get; set; }

    public GetOrderDetails(int orderId)
    {
        
        OrderId = orderId;
    }
}
