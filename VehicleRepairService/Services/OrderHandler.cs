using static VehicleRepairService.Model.Enums;
using VehicleRepairService.Model;

namespace VehicleRepairService.Domain
{
    public abstract class OrderHandler
    {
        protected OrderHandler NextHandler;

        public void SetNext(OrderHandler nextHandler)
        {
            NextHandler = nextHandler;
        }

        public abstract OrderStatus Handle(OrderRequest request);
    }

}
