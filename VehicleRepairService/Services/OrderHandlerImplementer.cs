using static VehicleRepairService.Model.Enums;
using VehicleRepairService.Model;

namespace VehicleRepairService.Domain
{
    public class LargeRepairOrderForNewCustomerHandler : OrderHandler
    {
        public override OrderStatus Handle(OrderRequest request)
        {
            if (request.IsLargeOrder && request.OrderType == OrderType.Repair && request.IsNewCustomer)
            {
                return OrderStatus.Closed;
            }

            return NextHandler?.Handle(request) ?? OrderStatus.Confirmed;
        }
    }

    public class LargeRushHireOrderHandler : OrderHandler
    {
        public override OrderStatus Handle(OrderRequest request)
        {
            if (request.IsLargeOrder && request.IsRushOrder && request.OrderType == OrderType.Hire)
            {
                return OrderStatus.Closed;
            }

            return NextHandler?.Handle(request) ?? OrderStatus.Confirmed;
        }
    }

    public class LargeRepairOrderHandler : OrderHandler
    {
        public override OrderStatus Handle(OrderRequest request)
        {
            if (request.IsLargeOrder && request.OrderType == OrderType.Repair)
            {
                return OrderStatus.AuthorisationRequired;
            }

            return NextHandler?.Handle(request) ?? OrderStatus.Confirmed;
        }
    }

    public class RushOrderForNewCustomerHandler : OrderHandler
    {
        public override OrderStatus Handle(OrderRequest request)
        {
            if (request.IsRushOrder && request.IsNewCustomer)
            {
                return OrderStatus.AuthorisationRequired;
            }

            return NextHandler?.Handle(request) ?? OrderStatus.Confirmed;
        }
    }

    public class DefaultHandler : OrderHandler
    {
        public override OrderStatus Handle(OrderRequest request)
        {
            return OrderStatus.Confirmed;
        }
    }

}
