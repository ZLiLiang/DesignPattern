namespace IteratorPattern;

/// <summary>
/// 迭代器接口
/// </summary>
public interface Iterator
{
    bool MoveNext();
    Object GetCurrent();
    void Next();
    void Reset();
}
