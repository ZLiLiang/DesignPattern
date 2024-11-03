using SingletonPattern;

Console.WriteLine("单例模式：");
Console.WriteLine("静态变量初始化实例");
StaticSingleton staticSingleton = StaticSingleton.Instance();
staticSingleton.GetInfo();

Console.WriteLine("");
Console.WriteLine("延迟初始化实例");
LazySingleton lazySingleton = LazySingleton.Instance();
lazySingleton.GetInfo();
lazySingleton.Reset();

Console.WriteLine("");
Console.WriteLine("泛型单例模式：");
GenericTest genericSingleton = GenericSingleton<GenericTest>.Instance();
genericSingleton.GetInfo();

Console.WriteLine("");
Console.WriteLine("锁机制确保多线程只产生一个实例");
for (int i = 0; i < 2; i++)
{
    Thread thread = new Thread(() =>
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: {Thread.CurrentThread.ThreadState}, Priority {Thread.CurrentThread.Priority}");
        LockSingleton lockSingleton = LockSingleton.Instance();
        lockSingleton.GetInfo();
        Console.WriteLine(lockSingleton.GetHashCode());
    });
    thread.Start();
}

Console.ReadLine();