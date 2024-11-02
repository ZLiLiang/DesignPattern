using IteratorPattern;

Console.WriteLine("迭代器模式：");
IListCollection list = new ConcreteList();
var iterator = list.GetIterator();

while (iterator.MoveNext())
{
    var element = iterator.GetCurrent();
    Console.WriteLine(element);
    iterator.Next();
}

Console.ReadLine();