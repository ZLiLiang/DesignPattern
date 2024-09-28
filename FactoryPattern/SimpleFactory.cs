namespace FactoryPattern;

/// <summary>
/// 简单工厂模式：<br/>
/// 简单工厂模式的工厂类一般是使用静态方法，通过接收的参数的不同来返回不同的对象实例。<br/>
/// 不修改代码的话，是无法扩展的。（如果增加新的产品，需要增加工厂的Swith分支）<br/>
/// 不符合【开放封闭原则】
/// </summary>
public static class SimpleFactory
{
    public static AbstractCar Create(ProductEnum productType)
    {
        AbstractCar result = productType switch
        {
            ProductEnum.ConcreateProductA => new ConcreateCarA(),
            ProductEnum.ConcreateProductB => new ConcreateCarB(),
            _ => throw new NotImplementedException(),
        };

        return result;
    }
}

/// <summary>
/// 产品枚举
/// </summary>
public enum ProductEnum
{
    ConcreateProductA,
    ConcreateProductB
}