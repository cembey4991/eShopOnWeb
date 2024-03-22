using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.GetAllOrders
{
    public class GetAll: IRequest<IEnumerable<GetAllOrderViewModel>>
    {

    }
}
