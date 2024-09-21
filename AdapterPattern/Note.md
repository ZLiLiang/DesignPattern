# 适配模式
将一个类的接口变换成客户端所期待的另一种接口，从而使原本因接口不匹配而无法在一起工作的两个类能够在一起工作。

待适配类（USB充电线类）
```
public class USBLine
{
    public void Charge()
    {
        Console.WriteLine("为设备充电！");
    }
}
```

接口标志适配标准（充电线接口）
```
public interface IChargingLine
{
    void Charging();
}
```

对象适配器模式（适配Type充电线类）
```
public class USBTypecLineAdapter : IChargingLine
{
    private readonly USBLine _usbLine;

    public USBTypecLineAdapter(USBLine usbLine)
    {
        _usbLine = usbLine;
    }

    public void Charging()
    {
        Console.WriteLine("对USB-TypeC端口的数据线进行适配！");
        this._usbLine.Charge();
    }
}
```

类适配器模式（适配lighting充电线类）
```
public class USBlightingLineAdapter : USBLine, IChargingLine
{
    public void Charging()
    {
        Console.WriteLine("对USB-Lighting端口的数据线进行适配！");
        base.Charge();
    }
}
```

## 优点
促进了类之间的协同工作，即使它们没有直接的关联。  
提高了类的复用性。  
增加了类的透明度。  
提供了良好的灵活性。

## 缺点
过度使用适配器可能导致系统结构混乱，难以理解和维护。  
由于只能继承一个类，因此只能适配一个类，且目标类必须是抽象的。

## 使用建议
适配器模式应谨慎使用，特别是在详细设计阶段，它更多地用于解决现有系统的问题。  
在考虑修改一个正常运行的系统接口时，适配器模式是一个合适的选择。