namespace SingletonPattern;

/// <summary>
/// 单例模式实现方式三：锁机制，确保多线程只产生一个实例
/// </summary>
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
