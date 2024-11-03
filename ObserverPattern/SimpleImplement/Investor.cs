namespace ObserverPattern.SimpleImplement;

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
