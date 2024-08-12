using System.Text.Json.Serialization;

namespace VehicleRepairService.Model
{
    public class Enums
    {
        public enum OrderType
        {
            Repair,
            Hire
        }

        public enum OrderStatus
        {
            Confirmed,
            Closed,
            AuthorisationRequired
        }

    }
}
