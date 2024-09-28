namespace FactoryPattern;

public abstract class AbstractCar
{
    protected abstract void DoOperation();

    public void GetInfo()
    {
        Console.WriteLine($"I am {this.GetType().Name}.");
    }
}

public abstract class AbstractBus
{
    protected abstract void DoOperation();

    public void GetInfo()
    {
        Console.WriteLine($"I am {this.GetType().Name}.");
    }
}

