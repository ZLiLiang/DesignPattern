namespace StatePattern;

/// <summary>
/// 状态接口
/// </summary>
public interface IDocumentState
{
    void Submit(Document document);
    void Publish(Document document);
}
