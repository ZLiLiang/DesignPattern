﻿namespace SingletonPattern;

/// <summary>
/// 泛型单例模式的实现
/// </summary>
/// <typeparam name="T"></typeparam>
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

public class GenericTest
{
    public void GetInfo()
    {
        Console.WriteLine("I am GenericSingleton.");
    }
}