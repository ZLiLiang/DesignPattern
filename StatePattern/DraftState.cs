namespace StatePattern;

/// <summary>
/// 草稿状态
/// </summary>
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
