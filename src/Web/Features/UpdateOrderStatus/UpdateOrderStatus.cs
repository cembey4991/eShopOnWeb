using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.UpdateOrderStatus
{
    public class UpdateOrderStatus: IRequest<UpdateOrderStatusViewModel>
    {
        public int OrderId { get; set; }

        public UpdateOrderStatus(int orderId)
        {

            OrderId = orderId;
        }
    }
}
