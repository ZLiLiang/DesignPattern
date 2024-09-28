namespace FactoryPattern;

/// <summary>
/// 宝马工厂
/// </summary>
public class BMWFactory : IFactory
{
    public AbstractCar CreateCar() => new ConcreateCarA();

    public AbstractBus CreateBus() => new ConcreateBusA();
}
