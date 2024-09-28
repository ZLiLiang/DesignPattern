# 简单工厂模式
提供了一种创建对象的方式，使得创建对象的过程与使用对象的过程分离。

抽象产品（抽象汽车类、抽象巴士类）
```
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
```

具体产品（汽车类、巴士类）
```
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
```

```
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
```

具体工厂（产品枚举、简单工厂类）
```
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
```

## 优点
调用者只需要知道对象的名称即可创建对象。  
扩展性高，如果需要增加新产品，只需扩展一个产品类即可。  
屏蔽了产品的具体实现，调用者只关心产品的接口。

## 缺点
每次增加一个产品时，都需要增加一个具体类，使系统中类的数量成倍增加，增加了系统的复杂度和具体类的依赖

## 使用场景
当工厂类负责创建的对象比较少时可以考虑使用简单工厂模式。


# 工厂方法模式

抽象产品（抽象汽车类、抽象巴士类）
```
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
```

具体产品（汽车类、巴士类）
```
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
```

```
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
```

抽象工厂（抽象工厂类）
```
public interface IFactoryMethod
{
    AbstractCar Create();
}
```

具体工厂（产品工厂类）
```
public class ConcreateFactoryA : IFactoryMethod
{
    public AbstractCar Create() => new ConcreateCarA();
}

public class ConcreateFactoryB : IFactoryMethod
{
    public AbstractCar Create() => new ConcreateCarB();
}
```

## 优点
**符合开放-关闭原则**：当需要添加新的产品时，只需扩展一个具体的工厂类，不需要修改现有的代码。  
**代码复用**：抽象工厂类中可以定义一些通用的产品创建逻辑，子类只需要扩展这些逻辑。  
**解耦产品与客户端**：客户端只需要知道产品的接口，不需要关心具体产品的实现类，有助于代码的维护和扩展。  
**增强灵活性**：可以通过引入多个工厂方法来创建不同类型的产品，灵活地配置和扩展系统。

## 缺点
**增加代码复杂性**：每增加一个新的产品类型，都需要增加一个具体的工厂类，这会增加系统的复杂度，特别是产品种类较多时。  
**难以应对产品族扩展**：如果系统中存在多个产品族，那么每个产品族都需要扩展相应的工厂类，管理多个工厂可能会比较繁琐。  
**类的数量增加**：由于每个具体产品都有其相应的工厂类，可能会导致系统中类的数量显著增加，影响代码的可维护性。

## 使用场景
当对象的创建过程比较复杂，比如需要执行某些初始化操作或依赖其他对象时，工厂方法可以将创建逻辑集中管理。  
当产品类型不确定，或者希望根据某些条件来决定创建哪种产品时，可以使用工厂方法模式来封装这些创建逻辑。  
当系统中不希望直接引用具体的产品类，而是通过接口或抽象类进行操作时，工厂方法模式非常适合。


# 反射工厂模式

抽象产品（抽象汽车类、抽象巴士类）
```
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
```

具体产品（汽车类、巴士类）
```
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
```

```
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
```

具体工厂（反射工厂类）
```
public static class ReflectFactory
{
    public static AbstractCar Create(string typeName)
    {
        Type type = Type.GetType(typeName, true, true) ?? throw new ArgumentNullException();
        AbstractCar instance = type.Assembly.CreateInstance(typeName) as AbstractCar ?? throw new ArgumentNullException();

        return instance;
    }
}
```

## 优点
**灵活性高**：可以在运行时动态地决定要实例化的类，消除了对特定类的编译时依赖。  
**减少代码冗余**：避免了为每个子类创建单独的工厂方法。通过反射工厂，多个类可以通过同一个工厂方法实例化。  
**扩展性强**：由于实例化是动态的，添加新的类不需要修改现有的工厂方法代码，符合“开闭原则”（对扩展开放，对修改关闭）。  
**支持配置驱动**：反射工厂可以通过配置文件（如 XML 或 JSON）或数据库驱动，轻松地根据配置创建不同类型的对象。

## 缺点
**性能开销**：反射是一种性能较低的操作，特别是在大量对象需要创建的场景中，反射的性能开销可能较大。  
**类型安全性差**：使用反射时，编译器无法进行类型检查，容易出现运行时错误。比如，反射实例化时可能会遇到类不存在或构造函数不匹配等异常。  
**调试困难**：由于是动态生成类实例，调试和跟踪代码时不如直接实例化清晰。  
**破坏封装**：反射机制可以绕过类的访问控制，可能会破坏类的封装性，增加潜在的安全隐患。

## 使用场景
当系统需要根据配置或用户输入动态加载并实例化插件时，可以使用反射工厂模式。  
反射工厂模式可以在 JSON、XML 或二进制数据反序列化时，根据描述动态创建对象。  
当需要动态生成类并且希望通过反射创建实例时。

# 抽象工厂模式

抽象产品（抽象汽车类、抽象巴士类）
```
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
```

具体产品（汽车类、巴士类）
```
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
```

```
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
```

抽象工厂（抽象工厂类）
```
public interface IFactory
    {
        AbstractCar CreateCar();
        AbstractBus CreateBus();
    }
```

具体工厂（产品工厂类）
```
public class BYDFactory : IFactory
{
    public AbstractCar CreateCar() => new ConcreateCarB();

    public AbstractBus CreateBus() => new ConcreateBusB();
}
```

```
public class BMWFactory : IFactory
{
    public AbstractCar CreateCar() => new ConcreateCarA();

    public AbstractBus CreateBus() => new ConcreateBusA();
}
```

## 优点
**分离具体类**：抽象工厂模式通过创建一组相关或依赖的对象，避免了客户端直接依赖于具体类，从而提高了代码的可维护性和可扩展性。  
**易于交换产品系列**：可以轻松地更换工厂以使用不同的产品系列，产品族之间不会互相影响。  
**一致性保证**：确保使用同一个产品系列中的对象，不会因为使用不同产品对象而导致不兼容问题。  

## 缺点
**复杂性增加**：随着产品族和工厂类的增加，代码的结构会变得复杂，维护成本上升。  
**扩展产品困难**：如果需要为产品家族添加新产品，所有的工厂类都需要修改，违反了开闭原则。  
**产品族约束**：产品族内的产品通常是紧密关联的，不太适合创建互不关联的对象。

## 使用场景
当系统需要一组相关或互相依赖的对象时，使用抽象工厂模式。例如，图形用户界面（GUI）库，Windows 和 macOS 的按钮、文本框等都是同一产品族的。  
如果一个系统需要创建多个对象，但又不希望指定这些对象的具体类时，可以使用抽象工厂模式。
