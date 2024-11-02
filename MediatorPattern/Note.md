# 中介者模式
定义了一个中介对象来封装一系列对象之间的交互。中介者使各对象之间不需要显式地相互引用，从而使其耦合松散，且可以独立地改变它们之间的交互。

中介者接口（订单中介接口类）
```
public interface IOrderMediator
{
    void ProcessOrder(Order order);
    void Notify(string message);
}
```

具体中介者（订单中介类）
```
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
```

被解耦组件（订单、库存、支付、发货类）
```
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

public class Inventory
{
    public bool CheckStock(int productId)
    {
        Random random = new Random();

        return random.Next(1, 100) > 50;
    }
}

public class Payment
{
    public bool ProcessPayment(decimal amount)
    {
        Random random = new Random();

        return random.Next(1, 100) > 50;
    }
}

public class Shipping
{
    public void ShipOrder(Order order)
    {
        Console.WriteLine($"订单 {order.ProductId} 已发货，金额: {order.Amount}");
    }
}
```

## 优点
**降低了对象之间的耦合**：中介者模式通过引入中介者对象，使得各个组件之间不需要直接通信，减少了对象之间的依赖关系。  
**集中管理交互逻辑**：所有的交互逻辑都集中在中介者中，方便管理和修改，增强了系统的可维护性。  
**提高了系统的灵活性**：新增或修改组件时，只需调整中介者，而无需更改组件间的相互关系。

## 缺点
**中介者可能变得过于复杂**：如果系统中组件较多或交互逻辑复杂，中介者可能变得臃肿，难以管理和维护。  
**增加了中介者的责任**：中介者负责管理多个组件的交互，可能导致单一责任原则被违反，使得中介者承担过多责任。  
**难以实现组件独立性**：尽管中介者模式解耦了组件间的直接联系，但组件依然依赖于中介者，降低了组件的独立性。

## 使用场景
**复杂交互的系统**：当系统中有多个对象相互通信，但通信关系复杂时，中介者模式可以有效简化这些关系。  
**多个组件之间需要协调时**：比如在一个聊天系统中，各个用户之间的消息传递可以通过中介者来协调。

## 注意事项
**保持中介者的简洁性**：应该保持中介者的逻辑简单，避免将过多的功能集中到一个中介者中。如果中介者过于复杂，可以考虑将其拆分。  
**明确组件间的职责**：各个组件应当有清晰的责任，确保中介者的作用仅限于协调，而不承担过多的逻辑。