namespace FactoryPattern;

/// <summary>
/// 反射工厂模式 <br/>
/// 是针对简单工厂模式的一种改进
/// </summary>
public static class ReflectFactory
{
    public static AbstractCar Create(string typeName)
    {
        Type type = Type.GetType(typeName, true, true) ?? throw new ArgumentNullException();
        AbstractCar instance = type.Assembly.CreateInstance(typeName) as AbstractCar ?? throw new ArgumentNullException();

        return instance;
    }
}
