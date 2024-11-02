namespace MediatorPattern;

public class OrderMediator : IOrderMediator
{
    private Inventory _inventory;
    private Payment _payment;
    private Shipping _shipping;

    public OrderMediator(Inventory inventory, Payment payment, Shipping shipping)
    {
        _inventory = inventory;
        _payment = payment;
        _shipping = shipping;
    }

    public void ProcessOrder(Order order)
    {
        if (_inventory.CheckStock(order.ProductId))
        {
            if (_payment.ProcessPayment(order.Amount))
            {
                _shipping.ShipOrder(order);
                Notify($"订单 {order.ProductId}订单处理成功，已发货！");
            }
            else
            {
                Notify($"订单 {order.ProductId}支付失败，请重试。");
            }
        }
        else
        {
            Notify($"订单 {order.ProductId}库存不足，无法处理订单。");
        }
    }

    public void Notify(string message)
    {
        Console.WriteLine($"通知: {message}");
    }
}
