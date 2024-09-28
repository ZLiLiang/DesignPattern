namespace FactoryPattern;

public class ConcreateBusA : AbstractBus
{
    protected override void DoOperation()
    {
        Console.WriteLine($"{this.GetType().Name} call DoOperation");
    }
}

public class ConcreateBusB : AbstractBus
{
    protected override void DoOperation()
    {
        Console.WriteLine($"{this.GetType().Name} call DoOperation");
    }
}
