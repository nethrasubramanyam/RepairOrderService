using VehicleRepairService.Domain;
using VehicleRepairService.Model;
using static VehicleRepairService.Model.Enums;

[TestFixture]
public class OrderServiceTests
{
    private IOrderService _orderService;

    [SetUp]
    public void SetUp()
    {
        _orderService = new OrderService();
    }

    [Test]
    public void ProcessOrder_LargeRepairOrderForNewCustomer_ReturnsClosed()
    {
        var request = new OrderRequest
        {
            IsLargeOrder = true,
            OrderType = OrderType.Repair,
            IsNewCustomer = true,
            IsRushOrder = false
        };

        var result = _orderService.ProcessOrder(request);

        Assert.That(result, Is.EqualTo(OrderStatus.Closed));
    }

    [Test]
    public void ProcessOrder_LargeRushHireOrder_ReturnsClosed()
    {
        var request = new OrderRequest
        {
            IsLargeOrder = true,
            OrderType = OrderType.Hire,
            IsNewCustomer = false,
            IsRushOrder = true
        };

        var result = _orderService.ProcessOrder(request);

        Assert.That(result, Is.EqualTo(OrderStatus.Closed));
    }

    [Test]
    public void ProcessOrder_LargeRepairOrder_ReturnsAuthorisationRequired()
    {
        var request = new OrderRequest
        {
            IsLargeOrder = true,
            OrderType = OrderType.Repair,
            IsNewCustomer = false,
            IsRushOrder = true
        };

        var result = _orderService.ProcessOrder(request);

        Assert.That(result, Is.EqualTo(OrderStatus.AuthorisationRequired));
    }

    [Test]
    public void ProcessOrder_RushOrderForNewCustomers_ReturnsAuthorisationRequired()
    {
        var request = new OrderRequest
        {
            IsLargeOrder = false,
            OrderType = OrderType.Hire,
            IsNewCustomer = true,
            IsRushOrder = true
        };

        var result = _orderService.ProcessOrder(request);

        Assert.That(result, Is.EqualTo(OrderStatus.AuthorisationRequired));
    }

    [Test]
    public void ProcessOrder_LargeOrders_ReturnsConfirmed()
    {
        var request = new OrderRequest
        {
            IsLargeOrder = true,
            OrderType = OrderType.Hire,
            IsNewCustomer = false,
            IsRushOrder = false
        };

        var result = _orderService.ProcessOrder(request);

        Assert.That(result, Is.EqualTo(OrderStatus.Confirmed));
    }
}
