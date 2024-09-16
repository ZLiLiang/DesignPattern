namespace BuilderPattern;

/// <summary>
/// 惠普电脑组装商
/// </summary>
public class HpBuilder : Builder
{
    private readonly Computer _hpComputer;

    public HpBuilder()
    {
        _hpComputer = new() { Band = "惠普" };
    }

    protected override void BuildMainFramePart()
    {
        _hpComputer.AssemblePart("主机");
    }

    protected override void BuildScreenPart()
    {
        _hpComputer.AssemblePart("显示器");
    }

    protected override void BuildInputPart()
    {
        _hpComputer.AssemblePart("键鼠");
    }

    /// <summary>
    /// 决定具体的组装步骤
    /// </summary>
    /// <returns></returns>
    public override Computer BuildComputer()
    {
        this.BuildMainFramePart();
        this.BuildScreenPart();
        this.BuildInputPart();

        return _hpComputer;
    }
}
