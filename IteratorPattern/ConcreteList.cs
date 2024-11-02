namespace IteratorPattern;

/// <summary>
/// 具体聚合类
/// </summary>
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
