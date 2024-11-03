# 单例模式
确保某一个类只有一个实例，而且自行实例化并向整个系统提供这个实例。

静态变量初始化（饿汉模式）
```
public class StaticSingleton
{
    /// <summary>
    /// 定义为static，可以保证变量为线程安全的，即每个线程一个实例
    /// </summary>
    private static StaticSingleton instance = new StaticSingleton();

    private StaticSingleton() { }

    public static StaticSingleton Instance() => instance;

    public void GetInfo()
    {
        Console.WriteLine($"I am {this.GetType().Name}.");
    }
}
```

延迟初始化（懒汉模式）
```
public class LazySingleton
{
    /// <summary>
    /// 定义为static，可以保证变量为线程安全的，即每个线程一个实例
    /// </summary>
    private static LazySingleton instance;

    private LazySingleton() { }

    public static LazySingleton Instance() => instance ??= new();

    /// <summary>
    /// 使用此方法销毁已创建的实例
    /// </summary>
    public void Reset()
    {
        instance = null;
    }

    public void GetInfo()
    {
        Console.WriteLine($"I am {this.GetType().Name}.");
    }
}
```

锁机制
```
public class LockSingleton
{
    private static LockSingleton instance;
    private static readonly object locker = new();

    private LockSingleton() { }

    public static LockSingleton Instance()
    {
        //没有第一重 instance == null 的话，每一次有线程进入 GetInstance()时，均会执行锁定操作来实现线程同步，
        //非常耗费性能 增加第一重instance ==null 成立时的情况下执行一次锁定以实现线程同步
        if (instance == null)
        {
            lock (locker)
            {
                //Double-Check Locking 双重检查锁定
                if (instance == null)
                {
                    instance = new();
                }
            }
        }

        return instance;
    }

    public void GetInfo()
    {
        Console.WriteLine($"I am {this.GetType().Name}.");
    }
}
```

泛型单例模式
```
public class GenericSingleton<T> where T : class
{
    private static T instance;
    private static readonly object locker = new();

    private GenericSingleton() { }

    public static T Instance()
    {
        //没有第一重 instance == null 的话，每一次有线程进入 GetInstance()时，均会执行锁定操作来实现线程同步，
        //非常耗费性能 增加第一重instance ==null 成立时的情况下执行一次锁定以实现线程同步
        if (instance == null)
        {
            //Double-Check Locking 双重检查锁定
            lock (locker)
            {
                if (instance == null)
                {
                    //需要非公共的无参构造函数，不能使用new T() ,new不支持非公共的无参构造函数 
                    //第二个参数防止异常：“没有为该对象定义无参数的构造函数。”
                    instance = Activator.CreateInstance(typeof(T), true) as T;
                }
            }
        }

        return instance;
    }
}
```

## 优点
- 内存中只有一个实例，减少内存开销，尤其是频繁创建和销毁实例时（如管理学院首页页面缓存）。
- 避免资源的多重占用（如写文件操作）。

## 缺点
- 没有接口，不能继承。
- 与单一职责原则冲突，一个类应该只关心内部逻辑，而不关心实例化方式。

## 使用场景
- 生成唯一序列号。
- WEB 中的计数器，避免每次刷新都在数据库中增加计数，先缓存起来。
- 创建消耗资源过多的对象，如 I/O 与数据库连接等。

## 注意事项
**线程安全**：Instance() 方法中需要使用同步锁 lock (locker) 防止多线程同时进入造成实例被多次创建。  
**延迟初始化**：实例在第一次调用 Instance() 方法时创建。  
**反射攻击**：在构造函数中添加防护代码，防止通过反射创建新实例。  
**类加载器问题**：注意复杂类加载环境可能导致的多个实例问题。