namespace ProxyPattern;

public class Database : IDataLoader
{
    public string LoadData()
    {
        Console.WriteLine("正在连接到数据库...");
        Thread.Sleep(2000); // 模拟耗时的操作
        return "数据已加载";
    }
}
