# 建造者模式
将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示。

产品（电脑类）
```
public class Computer
{
    /// <summary>
    /// 品牌
    /// </summary>
    public string Band { get; set; }

    /// <summary>
    /// 电脑组件列表
    /// </summary>
    private List<string> assemblyParts = [];

    /// <summary>
    /// 组装部件
    /// </summary>
    /// <param name="partName">部件名称</param>
    public void AssemblePart(string partName)
    {
        this.assemblyParts.Add(partName);
    }

    public void ShowSteps()
    {
        Console.WriteLine($"开始组装『{Band}』电脑:");

        foreach (var part in assemblyParts)
        {
            Console.WriteLine($"组装『{part}』;");
        }

        Console.WriteLine($"组装『{Band}』电脑完毕！");
    }
}
```

抽象建造者（抽象建造者类）
```
public abstract class Builder
{
    /// <summary>
    /// 组装主机
    /// </summary>
    protected abstract void BuildMainFramePart();

    /// <summary>
    /// 组装显示器
    /// </summary>
    protected abstract void BuildScreenPart();

    /// <summary>
    /// 组装输入设备（键鼠）
    /// </summary>
    protected abstract void BuildInputPart();

    /// <summary>
    /// 获取组装电脑
    /// 由具体的组装类决定组装顺序
    /// </summary>
    /// <returns></returns>
    public abstract Computer BuildComputer();
}
```

产品具体建造者（惠普、戴尔建造者类）
```
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
```

```
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
```

指令者（负责人类）
```
public class Director
{
    public Computer Construct(Builder builder)
    {
        return builder.BuildComputer();
    }
}
```