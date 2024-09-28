namespace FactoryPattern;

public class ConcreateCarA : AbstractCar
{
    protected override void DoOperation()
    {
        Console.WriteLine($"{this.GetType().Name} call DoOperation");
    }
}

public class ConcreateCarB : AbstractCar
{
    protected override void DoOperation()
    {
        Console.WriteLine($"{this.GetType().Name} call DoOperation");
    }
}