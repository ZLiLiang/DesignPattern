# 状态模式
当一个对象内在状态改变时允许其改变行为，这个对象看起来像改变了其类。

上下文（文档类）
```
public class Document
{
    private IDocumentState state;

    public Document()
    {
        // 初始状态为草稿状态
        state = new DraftState();
    }

    public void SetState(IDocumentState state)
    {
        this.state = state;
    }

    public void Submit()
    {
        state.Submit(this);
    }

    public void Publish()
    {
        state.Publish(this);
    }
}
```

状态（状态接口）
```
public interface IDocumentState
{
    void Submit(Document document);
    void Publish(Document document);
}
```

具体状态（草稿状态、审核状态和发布状态类）
```
public class DraftState : IDocumentState
{
    public void Submit(Document document)
    {
        Console.WriteLine("文档已提交审核。");
        document.SetState(new UnderReviewState());
    }

    public void Publish(Document document)
    {
        Console.WriteLine("文档不能发布，必须先提交审核。");
    }
}

public class UnderReviewState : IDocumentState
{
    public void Submit(Document document)
    {
        Console.WriteLine("文档已在审核中，无法再次提交。");
    }

    public void Publish(Document document)
    {
        Console.WriteLine("文档已发布。");
        document.SetState(new PublishedState());
    }
}

public class PublishedState : IDocumentState
{
    public void Submit(Document document)
    {
        Console.WriteLine("文档已发布，无法提交审核。");
    }

    public void Publish(Document document)
    {
        Console.WriteLine("文档已经是发布状态。");
    }
}
```

## 优点
**封装状态转换规则**：将状态转换逻辑封装在状态对象内部。  
**易于扩展**：增加新的状态类不会影响现有代码。  
**集中状态相关行为**：将所有与特定状态相关的行为集中到一个类中。  
**简化条件语句**：避免使用大量的条件语句来切换行为。  
**状态共享**：允许多个上下文对象共享同一个状态对象。

## 缺点
**增加类和对象数量**：每个状态都需要一个具体的状态类。  
**实现复杂**：模式结构和实现相对复杂。  
**开闭原则支持不足**：增加新状态或修改状态行为可能需要修改现有代码。  

## 使用场景
- 当对象的行为随状态改变而变化时，考虑使用状态模式。  
- 状态模式适用于替代复杂的条件或分支语句。

## 注意事项
- 状态模式适用于状态数量有限（通常不超过5个）的情况。  
- 谨慎使用，以避免系统变得过于复杂。