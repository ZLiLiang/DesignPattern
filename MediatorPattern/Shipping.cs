namespace MediatorPattern;

/// <summary>
/// 发货类
/// </summary>
public class Shipping
{
    public void ShipOrder(Order order)
    {
        Console.WriteLine($"订单 {order.ProductId} 已发货，金额: {order.Amount}");
    }
}
