# �򵥹���ģʽ
�ṩ��һ�ִ�������ķ�ʽ��ʹ�ô�������Ĺ�����ʹ�ö���Ĺ��̷��롣

�����Ʒ�����������ࡢ�����ʿ�ࣩ
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

�����Ʒ�������ࡢ��ʿ�ࣩ
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

���幤������Ʒö�١��򵥹����ࣩ
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
/// ��Ʒö��
/// </summary>
public enum ProductEnum
{
    ConcreateProductA,
    ConcreateProductB
}
```

## �ŵ�
������ֻ��Ҫ֪����������Ƽ��ɴ�������  
��չ�Ըߣ������Ҫ�����²�Ʒ��ֻ����չһ����Ʒ�༴�ɡ�  
�����˲�Ʒ�ľ���ʵ�֣�������ֻ���Ĳ�Ʒ�Ľӿڡ�

## ȱ��
ÿ������һ����Ʒʱ������Ҫ����һ�������࣬ʹϵͳ����������ɱ����ӣ�������ϵͳ�ĸ��ӶȺ;����������

## ʹ�ó���
�������ฺ�𴴽��Ķ���Ƚ���ʱ���Կ���ʹ�ü򵥹���ģʽ��


# ��������ģʽ

�����Ʒ�����������ࡢ�����ʿ�ࣩ
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

�����Ʒ�������ࡢ��ʿ�ࣩ
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

���󹤳������󹤳��ࣩ
```
public interface IFactoryMethod
{
    AbstractCar Create();
}
```

���幤������Ʒ�����ࣩ
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

## �ŵ�
**���Ͽ���-�ر�ԭ��**������Ҫ����µĲ�Ʒʱ��ֻ����չһ������Ĺ����࣬����Ҫ�޸����еĴ��롣  
**���븴��**�����󹤳����п��Զ���һЩͨ�õĲ�Ʒ�����߼�������ֻ��Ҫ��չ��Щ�߼���  
**�����Ʒ��ͻ���**���ͻ���ֻ��Ҫ֪����Ʒ�Ľӿڣ�����Ҫ���ľ����Ʒ��ʵ���࣬�����ڴ����ά������չ��  
**��ǿ�����**������ͨ������������������������ͬ���͵Ĳ�Ʒ���������ú���չϵͳ��

## ȱ��
**���Ӵ��븴����**��ÿ����һ���µĲ�Ʒ���ͣ�����Ҫ����һ������Ĺ����࣬�������ϵͳ�ĸ��Ӷȣ��ر��ǲ�Ʒ����϶�ʱ��  
**����Ӧ�Բ�Ʒ����չ**�����ϵͳ�д��ڶ����Ʒ�壬��ôÿ����Ʒ�嶼��Ҫ��չ��Ӧ�Ĺ����࣬�������������ܻ�ȽϷ�����  
**�����������**������ÿ�������Ʒ��������Ӧ�Ĺ����࣬���ܻᵼ��ϵͳ����������������ӣ�Ӱ�����Ŀ�ά���ԡ�

## ʹ�ó���
������Ĵ������̱Ƚϸ��ӣ�������Ҫִ��ĳЩ��ʼ��������������������ʱ�������������Խ������߼����й���  
����Ʒ���Ͳ�ȷ��������ϣ������ĳЩ�����������������ֲ�Ʒʱ������ʹ�ù�������ģʽ����װ��Щ�����߼���  
��ϵͳ�в�ϣ��ֱ�����þ���Ĳ�Ʒ�࣬����ͨ���ӿڻ��������в���ʱ����������ģʽ�ǳ��ʺϡ�


# ���乤��ģʽ

�����Ʒ�����������ࡢ�����ʿ�ࣩ
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

�����Ʒ�������ࡢ��ʿ�ࣩ
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

���幤�������乤���ࣩ
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

## �ŵ�
**����Ը�**������������ʱ��̬�ؾ���Ҫʵ�������࣬�����˶��ض���ı���ʱ������  
**���ٴ�������**��������Ϊÿ�����ഴ�������Ĺ���������ͨ�����乤������������ͨ��ͬһ����������ʵ������  
**��չ��ǿ**������ʵ�����Ƕ�̬�ģ�����µ��಻��Ҫ�޸����еĹ����������룬���ϡ�����ԭ�򡱣�����չ���ţ����޸Ĺرգ���  
**֧����������**�����乤������ͨ�������ļ����� XML �� JSON�������ݿ����������ɵظ������ô�����ͬ���͵Ķ���

## ȱ��
**���ܿ���**��������һ�����ܽϵ͵Ĳ������ر����ڴ���������Ҫ�����ĳ����У���������ܿ������ܽϴ�  
**���Ͱ�ȫ�Բ�**��ʹ�÷���ʱ���������޷��������ͼ�飬���׳�������ʱ���󡣱��磬����ʵ����ʱ���ܻ������಻���ڻ��캯����ƥ����쳣��  
**��������**�������Ƕ�̬������ʵ�������Ժ͸��ٴ���ʱ����ֱ��ʵ����������  
**�ƻ���װ**��������ƿ����ƹ���ķ��ʿ��ƣ����ܻ��ƻ���ķ�װ�ԣ�����Ǳ�ڵİ�ȫ������

## ʹ�ó���
��ϵͳ��Ҫ�������û��û����붯̬���ز�ʵ�������ʱ������ʹ�÷��乤��ģʽ��  
���乤��ģʽ������ JSON��XML ����������ݷ����л�ʱ������������̬��������  
����Ҫ��̬�����ಢ��ϣ��ͨ�����䴴��ʵ��ʱ��

# ���󹤳�ģʽ

�����Ʒ�����������ࡢ�����ʿ�ࣩ
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

�����Ʒ�������ࡢ��ʿ�ࣩ
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

���󹤳������󹤳��ࣩ
```
public interface IFactory
    {
        AbstractCar CreateCar();
        AbstractBus CreateBus();
    }
```

���幤������Ʒ�����ࣩ
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

## �ŵ�
**���������**�����󹤳�ģʽͨ������һ����ػ������Ķ��󣬱����˿ͻ���ֱ�������ھ����࣬�Ӷ�����˴���Ŀ�ά���ԺͿ���չ�ԡ�  
**���ڽ�����Ʒϵ��**���������ɵظ���������ʹ�ò�ͬ�Ĳ�Ʒϵ�У���Ʒ��֮�䲻�ụ��Ӱ�졣  
**һ���Ա�֤**��ȷ��ʹ��ͬһ����Ʒϵ���еĶ��󣬲�����Ϊʹ�ò�ͬ��Ʒ��������²��������⡣  

## ȱ��
**����������**�����Ų�Ʒ��͹���������ӣ�����Ľṹ���ø��ӣ�ά���ɱ�������  
**��չ��Ʒ����**�������ҪΪ��Ʒ��������²�Ʒ�����еĹ����඼��Ҫ�޸ģ�Υ���˿���ԭ��  
**��Ʒ��Լ��**����Ʒ���ڵĲ�Ʒͨ���ǽ��ܹ����ģ���̫�ʺϴ������������Ķ���

## ʹ�ó���
��ϵͳ��Ҫһ����ػ��������Ķ���ʱ��ʹ�ó��󹤳�ģʽ�����磬ͼ���û����棨GUI���⣬Windows �� macOS �İ�ť���ı���ȶ���ͬһ��Ʒ��ġ�  
���һ��ϵͳ��Ҫ����������󣬵��ֲ�ϣ��ָ����Щ����ľ�����ʱ������ʹ�ó��󹤳�ģʽ��
