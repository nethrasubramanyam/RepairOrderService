using Microsoft.AspNetCore.Mvc;
using static VehicleRepairService.Model.Enums;
using VehicleRepairService.Model;
using VehicleRepairService.Domain;

namespace VehicleRepairService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("process")]
        public ActionResult<OrderStatus> ProcessOrder([FromBody] OrderRequest request)
        {
            var status = _orderService.ProcessOrder(request);
            return Ok(status);
        }
    }

}

