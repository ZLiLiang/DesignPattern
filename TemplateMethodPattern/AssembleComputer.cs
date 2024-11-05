namespace TemplateMethodPattern;

/// <summary>
/// 组装电脑
/// </summary>
public abstract class AssembleComputer
{
    /// <summary>
    /// 组装主机
    /// </summary>
    public abstract void BuildMainFramePart();

    /// <summary>
    /// 组装显示器
    /// </summary>
    public abstract void BuildScreenPart();

    /// <summary>
    /// 组装输入设备（键鼠）
    /// </summary>
    public abstract void BuildInputPart();

    /// <summary>
    /// 组装起来
    /// </summary>
    public void Assemble()
    {
        BuildMainFramePart();
        BuildScreenPart();
        BuildInputPart();
    }
}
