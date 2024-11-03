namespace StatePattern;

/// <summary>
/// 文档类
/// </summary>
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
