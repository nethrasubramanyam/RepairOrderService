using static VehicleRepairService.Model.Enums;
using VehicleRepairService.Model;

namespace VehicleRepairService.Domain
{
    public interface IOrderService
    {
        OrderStatus ProcessOrder(OrderRequest request);
    }

    public class OrderService : IOrderService
    {
        private readonly OrderHandler _handler;

        public OrderService()
        {
            // Build the chain of handlers
            var largeRepairOrderForNewCustomerHandler = new LargeRepairOrderForNewCustomerHandler();
            var largeRushHireOrderHandler = new LargeRushHireOrderHandler();
            var largeRepairOrderHandler = new LargeRepairOrderHandler();
            var rushOrderForNewCustomerHandler = new RushOrderForNewCustomerHandler();
            var defaultHandler = new DefaultHandler();

            largeRepairOrderForNewCustomerHandler.SetNext(largeRushHireOrderHandler);
            largeRushHireOrderHandler.SetNext(largeRepairOrderHandler);
            largeRepairOrderHandler.SetNext(rushOrderForNewCustomerHandler);
            rushOrderForNewCustomerHandler.SetNext(defaultHandler);

            _handler = largeRepairOrderForNewCustomerHandler;
        }

        public OrderStatus ProcessOrder(OrderRequest request)
        {
            return _handler.Handle(request);
        }
    }

}
