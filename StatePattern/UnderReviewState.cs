namespace StatePattern;

/// <summary>
/// 审核状态
/// </summary>
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
