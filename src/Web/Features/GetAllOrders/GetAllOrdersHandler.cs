using MediatR;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.GetAllOrders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAll, IEnumerable<GetAllOrderViewModel>>
    {
        private readonly IReadRepository<Order> _orderRepository;
    

        public GetAllOrdersHandler(IReadRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
          
        }

        public async Task<IEnumerable<GetAllOrderViewModel>> Handle(GetAll request,
            CancellationToken cancellationToken)
        {
            var specification = new GetAllOrdersSpecification();
            var orders = await _orderRepository.ListAsync(specification, cancellationToken);
          

            return orders.Select(o => new GetAllOrderViewModel
            {
                Status=o.Status,
                Email=o.BuyerId,
                OrderDate = o.OrderDate,
                OrderNumber = o.Id,
                Total = o.Total()
            });
        }
    }
}
