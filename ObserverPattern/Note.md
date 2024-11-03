# 观察者模式
定义对象间一种一对多的依赖关系，使得每当一个对象改变状态，则所有依赖于它的对象都会得到通知并被自动更新。

### 接口实现
观察者接口
```
public interface IObserver
{
    void Update(decimal price);
}
```

被观察者接口
```
public interface IObservable
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
```

实现被观察者（股票类）
```
public class Stock : IObservable
{
    private List<IObserver> observers = [];
    private decimal price;

    public decimal Price
    {
        get => price;
        set
        {
            price = value;
            NotifyObservers();
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(price);
        }
    }
}
```

实现具体的观察者（投资者类）
```
public class Investor : IObserver
{
    public string Name { get; }

    public Investor(string name)
    {
        Name = name;
    }

    public void Update(decimal price)
    {
        Console.WriteLine($"投资者 {Name} 收到通知: 股票价格更新为 {price}");
    }
}
```

### 委托实现
被观察者（股票类）
```
public class Stock
{
    // 定义委托类型，用于价格变化通知
    public delegate void PriceChangedHandler(decimal newPrice);

    // 定义事件，类型为 PriceChangedHandler
    public event PriceChangedHandler PriceChanged;

    private decimal price;
    public decimal Price
    {
        get { return price; }
        set
        {
            price = value;
            // 当价格变化时触发 PriceChanged 事件
            OnPriceChanged(price);
        }
    }

    // 触发 PriceChanged 事件的方法
    protected virtual void OnPriceChanged(decimal newPrice)
    {
        if (PriceChanged != null)
        {
            PriceChanged(newPrice);
        }
    }
}
```

具体的观察者（投资者类）
```
public class Investor
{
    public string Name { get; }

    public Investor(string name)
    {
        Name = name;
    }

    // 回调方法，当股票价格变化时接收通知
    public void OnStockPriceChanged(decimal newPrice)
    {
        Console.WriteLine($"投资者 {Name} 收到通知: 股票价格更新为 {newPrice}");
    }
}
```

## 优点
**抽象耦合**：观察者和主题之间是抽象耦合的。  
**触发机制**：建立了一套状态改变时的触发和通知机制。

## 缺点
**性能问题**：如果观察者众多，通知过程可能耗时。  
**循环依赖**：可能导致循环调用和系统崩溃。  
**缺乏变化详情**：观察者不知道主题如何变化，只知道变化发生。

## 使用场景
在需要降低对象间耦合度，并且对象状态变化需要触发其他对象变化时使用。

## 注意事项
**避免循环引用**：注意观察者和主题之间的依赖关系，避免循环引用。  
**异步执行**：考虑使用异步通知避免单点故障导致整个系统卡壳。