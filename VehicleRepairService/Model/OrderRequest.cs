using System.Text.Json.Serialization;
using static VehicleRepairService.Model.Enums;

namespace VehicleRepairService.Model
{

    public class OrderRequest
    {
        public bool IsRushOrder { get; set; }
        public OrderType OrderType { get; set; }
        public bool IsNewCustomer { get; set; }
        public bool IsLargeOrder { get; set; }
    }


}
