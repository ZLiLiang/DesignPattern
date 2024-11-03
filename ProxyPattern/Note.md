# 代理模式
通过引入一个代理对象来控制对原对象的访问。代理对象在客户端和目标对象之间充当中介，负责将客户端的请求转发给目标对象，同时可以在转发请求前后进行额外的处理。

抽象主题（数据加载接口）
```
public interface IDataLoader
{
    string LoadData();
}
```

真实主题（数据库类）
```
public class Database : IDataLoader
{
    public string LoadData()
    {
        Console.WriteLine("正在连接到数据库...");
        Thread.Sleep(2000); // 模拟耗时的操作
        return "数据已加载";
    }
}
```

代理（数据库代理类）
```
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
```

## 优点
**职责分离**：代理模式将访问控制与业务逻辑分离。  
**扩展性**：可以灵活地添加额外的功能或控制。  
**智能化**：可以智能地处理访问请求，如延迟加载、缓存等。

## 缺点
**性能开销**：增加了代理层可能会影响请求的处理速度。 
**实现复杂性**：某些类型的代理模式实现起来可能较为复杂。

## 使用场景
- 根据具体需求选择合适的代理类型，如远程代理、虚拟代理、保护代理等。  
- 确保代理类与真实对象接口一致，以便客户端透明地使用代理。

## 注意事项
**与适配器模式的区别**：适配器模式改变接口，而代理模式不改变接口。  
**与装饰器模式的区别**：装饰器模式用于增强功能，代理模式用于控制访问。