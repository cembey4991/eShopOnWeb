using MediatR;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.Web.ViewModels;
using Microsoft.eShopWeb.ApplicationCore.Extensions;
using Microsoft.eShopWeb.ApplicationCore.Enums;
namespace Microsoft.eShopWeb.Web.Features.UpdateOrderStatus
{
    public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatus, UpdateOrderStatusViewModel?>
    {
        private readonly IRepository<Order> _orderRepository;

        public UpdateOrderStatusHandler(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<UpdateOrderStatusViewModel?> Handle(UpdateOrderStatus request,
            CancellationToken cancellationToken)
        {
            var spec = new OrderWithItemsByIdSpec(request.OrderId);
            var order = await _orderRepository.FirstOrDefaultAsync(spec, cancellationToken);

            if (order == null)
            {
                return null;
            }

            order.Status = OrderStatus.Approved.GetDisplayName();
            await _orderRepository.UpdateAsync(order);
            await _orderRepository.SaveChangesAsync();
            return new UpdateOrderStatusViewModel
            {
                Success = true
            };
        }
    }
}
