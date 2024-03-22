using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications
{
    public class GetAllOrdersSpecification:Specification<Order>
    {
        public GetAllOrdersSpecification()
        {
                Query
            .Include(o => o.OrderItems)
            .ThenInclude(i => i.ItemOrdered);
        }
    }
}
