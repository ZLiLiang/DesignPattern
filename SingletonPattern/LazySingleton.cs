namespace SingletonPattern;

/// <summary>
/// 单例模式实现方式二：延迟初始化
/// </summary>
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
