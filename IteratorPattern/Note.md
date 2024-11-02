# 迭代器模式
提供一种方法访问一个容器对象中各个元素，而又不需暴露该对象的内部细节。

迭代器角色（迭代器接口）
```
public interface Iterator
{
    bool MoveNext();
    Object GetCurrent();
    void Next();
    void Reset();
}
```

具体迭代器角色（具体迭代器类）
```
public class ConcreteIterator : Iterator
{
    // 迭代器要集合对象进行遍历操作，自然就需要引用集合对象
    private ConcreteList _list;
    private int _index;

    public ConcreteIterator(ConcreteList list)
    {
        _list = list;
        _index = 0;
    }

    public bool MoveNext()
    {
        if (_index < _list.Length)
        {
            return true;
        }

        return false;
    }

    public object GetCurrent()
    {
        return _list.GetElement(_index);
    }

    public void Next()
    {
        if (_index < _list.Length)
        {
            _index++;
        }
    }

    public void Reset()
    {
        _index = 0;
    }
}
```

聚合角色（聚合接口）
```
public interface IListCollection
{
    Iterator GetIterator();
}
```

具体聚合角色（具体聚合类）
```
public class ConcreteList : IListCollection
{
    private readonly string[] _collection;

    public ConcreteList()
    {
        _collection = ["A", "B", "C", "D"];
    }

    public Iterator GetIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Length => _collection.Length;

    public string GetElement(int index) => _collection[index];
}
```

## 优点
**支持多种遍历方式**：不同的迭代器可以定义不同的遍历方式。  
**简化聚合类**：聚合类不需要关心遍历逻辑。  
**多遍历支持**：可以同时对同一个聚合对象进行多次遍历。  
**扩展性**：增加新的聚合类和迭代器类都很方便，无需修改现有代码。

## 缺点
**系统复杂性**：每增加一个聚合类，就需要增加一个对应的迭代器类，增加了类的数量。

## 使用场景
当需要访问聚合对象内容而不暴露其内部表示时，使用迭代器模式。  
当需要为聚合对象提供多种遍历方式时，考虑使用迭代器模式。

## 注意事项
系统需要访问一个聚合对象的内容而无需暴露它的内部表示。  
系统需要支持对聚合对象的多种遍历。  
该模式在.net中，可以通过实现IEnumberable接口即可，不再需要单独实现。