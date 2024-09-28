namespace FactoryPattern;

public class BYDFactory : IFactory
{
    public AbstractCar CreateCar() => new ConcreateCarB();

    public AbstractBus CreateBus() => new ConcreateBusB();
}
