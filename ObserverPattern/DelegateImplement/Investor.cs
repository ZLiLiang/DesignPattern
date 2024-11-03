namespace ObserverPattern.DelegateImplement;

/// <summary>
/// 观察者
/// </summary>
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
