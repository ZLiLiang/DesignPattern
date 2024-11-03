namespace StatePattern;

/// <summary>
/// 发布状态
/// </summary>
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
