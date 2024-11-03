namespace SingletonPattern;

/// <summary>
/// 单例模式实现方式一：静态变量初始化
/// </summary>
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
