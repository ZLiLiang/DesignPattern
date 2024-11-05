# 模板模式
定义一个操作中算法的框架，而将一些步骤延迟到子类中。使得子类可以不改变一个算法的结构即可重定义该算法的某些特定步骤。

抽象父类（抽象组装电脑类）
```
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
```

具体子类（组装惠普电脑、组装戴尔电脑类）
```
public class AssembleHpComputer : AssembleComputer
{
    public override void BuildMainFramePart()
    {
        Console.WriteLine("组装HP电脑的主板");
    }

    public override void BuildScreenPart()
    {
        Console.WriteLine("组装HP电脑的显示器");
    }

    public override void BuildInputPart()
    {
        Console.WriteLine("组装HP电脑的键盘鼠标");
    }
}

public class AssembleDellComputer : AssembleComputer
{
    public override void BuildMainFramePart()
    {
        Console.WriteLine("组装Dell电脑的主板");
    }

    public override void BuildScreenPart()
    {
        Console.WriteLine("组装Dell电脑的显示器");
    }

    public override void BuildInputPart()
    {
        Console.WriteLine("组装Dell电脑的键盘鼠标");
    }
}
```

## 优点
**封装不变部分**：算法的不变部分被封装在父类中。  
**扩展可变部分**：子类可以扩展或修改算法的可变部分。  
**提取公共代码**：减少代码重复，便于维护。

## 缺点
**类数目增加**：每个不同的实现都需要一个子类，可能导致系统庞大。

## 使用场景
- 当有多个子类共有的方法且逻辑相同时，考虑使用模板方法模式。
- 对于重要或复杂的方法，可以考虑作为模板方法定义在父类中。

## 注意事项
- 为了防止恶意修改，模板方法通常使用final关键字修饰，避免被子类重写。