using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopWeb.Web.Features.GetAllOrders;
using Microsoft.eShopWeb.Web.Features.OrderDetails;
using Microsoft.eShopWeb.Web.ViewModels;
using Microsoft.eShopWeb.Web.Features.UpdateOrderStatus;

namespace Microsoft.eShopWeb.Web.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public  IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var viewModel = await _mediator.Send(new GetAll());
            return Ok(viewModel);
        }
        [HttpGet]
        [Route("OrderDetail")]
        public async Task<IActionResult> OrderDetail(int orderNumber)
        {
            var viewModel = await _mediator.Send(new GetOrderDetails(orderNumber));
            return PartialView("_OrderDetailPartial", viewModel);
        }
        [HttpPost]
        [Route("OrderUpdate")]
        public async Task<IActionResult> OrderUpdate(OrderDetailViewModel model)
        {
        var viewModel = await _mediator.Send(new UpdateOrderStatus(model.OrderNumber));
        return RedirectToAction("Index");
        }
    }
}
