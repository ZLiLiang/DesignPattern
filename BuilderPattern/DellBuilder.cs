namespace BuilderPattern;

/// <summary>
/// 戴尔电脑组装商
/// </summary>
public class DellBuilder : Builder
{
    private readonly Computer _dellComputer;

    public DellBuilder()
    {
        _dellComputer = new() { Band = "戴尔" };
    }

    protected override void BuildMainFramePart()
    {
        _dellComputer.AssemblePart("主机");
    }

    protected override void BuildScreenPart()
    {
        _dellComputer.AssemblePart("显示器");
    }

    protected override void BuildInputPart()
    {
        _dellComputer.AssemblePart("键鼠");
    }

    public override Computer BuildComputer()
    {
        this.BuildMainFramePart();
        this.BuildScreenPart();
        this.BuildInputPart();

        return _dellComputer;
    }
}
