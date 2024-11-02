namespace IteratorPattern;

/// <summary>
/// 具体迭代器类
/// </summary>
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
