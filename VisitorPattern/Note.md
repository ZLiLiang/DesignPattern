# 访问者模式
封装一些作用于某种数据结构中的各元素的操作，它可以在不改变数据结构的前提下定义作用于这些元素的新的操作。

访问者（访问者接口）
```
public interface IVisitor
{
    public abstract void Visit(SaleOrder saleOrder);
    public abstract void Visit(ReturnOrder returnOrder);
}
```

具体访问者（挑拣员、收发货员类）
```
public class Picker : IVisitor
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Visit(SaleOrder saleOrder)
    {
        Console.WriteLine($"开始为销售订单【{saleOrder.Id}】进行销售捡货处理：");
        foreach (var item in saleOrder.OrderItems)
        {
            Console.WriteLine($"【{item.Product.Name}】商品* {item.Qty}");
        }

        Console.WriteLine($"订单【{saleOrder.Id}】捡货完毕！");

        Console.WriteLine("==========================");
    }

    public void Visit(ReturnOrder returnOrder)
    {
        Console.WriteLine($"开始为退货订单【{returnOrder.Id}】进行退货捡货处理：");
        foreach (var item in returnOrder.OrderItems)
        {
            Console.WriteLine($"【{item.Product.Name}】商品* {item.Qty}");
        }

        Console.WriteLine($"退货订单【{returnOrder.Id}】退货捡货完毕！", returnOrder.Id);
        Console.WriteLine("==========================");
    }
}

public class Distributor : IVisitor
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Visit(SaleOrder saleOrder)
    {
        Console.WriteLine($"开始为销售订单【{saleOrder.Id}】进行发货处理：", saleOrder.Id);

        Console.WriteLine($"一共打包{saleOrder.OrderItems.Sum(line => line.Qty)}件商品。");
        Console.WriteLine($"收货人：{saleOrder.Customer.RealName}");
        Console.WriteLine($"联系电话：{saleOrder.Customer.Phone}");
        Console.WriteLine($"收货地址：{saleOrder.Customer.Address}");
        Console.WriteLine($"邮政编码：{saleOrder.Customer.Zip}");

        Console.WriteLine($"订单【{saleOrder.Id}】发货完毕！");
        Console.WriteLine("==========================");
    }

    public void Visit(ReturnOrder returnOrder)
    {
        Console.WriteLine($"收到来自【{returnOrder.Customer.NickName}】的退货订单【{returnOrder.Id}】，进行退货收货处理：");

        foreach (var item in returnOrder.OrderItems)
        {
            Console.WriteLine($"【{item.Product.Name}】商品* {item.Qty}");
        }

        Console.WriteLine($"退货订单【{returnOrder.Id}】收货处理完毕！");
        Console.WriteLine("==========================");
    }
}
```

元素（订单类）
```
public abstract class Order
{
    public int Id { get; set; }

    public Customer Customer { get; set; }

    public DateTime CreatorDate { get; set; }

    /// <summary>
    /// 单据品相
    /// </summary>
    public List<OrderLine> OrderItems { get; set; }

    public abstract void Accept(IVisitor visitor);

} 
```

具体元素（销售单、退货单类）
```
public class SaleOrder : Order
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class ReturnOrder : Order
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
```

对象结构（订单中心类）
```
public class OrderCenter : List<Order>
{
    public void Accept(IVisitor visitor)
    {
        var iterator = this.GetEnumerator();

        while (iterator.MoveNext())
        {
            iterator.Current.Accept(visitor);
        }
    }

}
```

## 优点
**单一职责原则**：访问者模式符合单一职责原则，每个类只负责一项职责。  
**扩展性**：容易为数据结构添加新的操作。  
**灵活性**：访问者可以独立于数据结构变化。

## 缺点
**违反迪米特原则**：元素需要向访问者公开其内部信息。  
**元素类难以变更**：元素类需要维持与访问者的兼容。  
**依赖具体类**：访问者模式依赖于具体类而不是接口，违反了依赖倒置原则。  

## 使用场景
- 当对象结构稳定，但需要在其上定义多种新操作时，考虑使用访问者模式。
- 当需要避免操作"污染"对象类时，使用访问者模式封装操作。

## 注意事项
- 访问者模式可以用于功能统一，如报表生成、用户界面显示、拦截器和过滤器等。