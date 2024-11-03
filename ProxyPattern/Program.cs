using ProxyPattern;

IDataLoader dataLoader = new DatabaseProxy();

Console.WriteLine("======= 第一次调用，加载数据 =======");
Console.WriteLine(dataLoader.LoadData());

Console.WriteLine("         ");

Console.WriteLine("======= 第二次调用，从缓存中返回数据 =======");
Console.WriteLine(dataLoader.LoadData());

Console.ReadLine();