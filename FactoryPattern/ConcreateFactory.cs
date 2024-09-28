namespace FactoryPattern;

public class ConcreateFactoryA : IFactoryMethod
{
    public AbstractCar Create() => new ConcreateCarA();
}

public class ConcreateFactoryB : IFactoryMethod
{
    public AbstractCar Create() => new ConcreateCarB();
}