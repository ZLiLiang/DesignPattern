namespace ProxyPattern;

public class DatabaseProxy : IDataLoader
{
    private Database database;
    private string cachedData;

    public string LoadData()
    {
        if (database == null)
        {
            Console.WriteLine("创建实际的 Database 实例并加载数据...");
            database = new Database();
            cachedData = database.LoadData();
        }
        else
        {
            Console.WriteLine("直接从缓存中返回数据...");
        }

        return cachedData;
    }
}
