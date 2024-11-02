namespace MediatorPattern;

/// <summary>
/// 订单类
/// </summary>
public class Order
{
    public int ProductId { get; set; }
    public decimal Amount { get; set; }

    public Order(int productId, decimal amount)
    {
        ProductId = productId;
        Amount = amount;
    }
}
