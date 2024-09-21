# 装饰模式

动态地给一个对象添加额外的职责，同时不改变其结构。装饰器模式提供了一种灵活的替代继承方式来扩展功能。

组件（抽象房子类）
```
public abstract class AbstractHouse
{
    /// <summary>
    /// 面积
    /// </summary>
    public double Area { get; set; }

    /// <summary>
    /// 规格
    /// </summary>
    public string Specification { get; set; }

    /// <summary>
    /// 价格
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// 定义抽象方法--展示
    /// </summary>
    public abstract void Show();
}
```

具体组件（毛胚房子类）
```
public class WithoutDecoratorHouse : AbstractHouse
{
    /// <summary>
    /// 毛坯房就做简要展示
    /// </summary>
    public override void Show()
    {
        Console.WriteLine($"该户型为{this.Area}㎡，户型设计为{this.Specification}，目前均价为{this.Price}元/㎡。");
    }
}
```

抽象装饰者（抽象未装饰房子类）
```
public abstract class DecoratorHouse : AbstractHouse
{
    private readonly AbstractHouse _house;

    protected DecoratorHouse(AbstractHouse house)
    {
        _house = house;
    }

    public override void Show()
    {
        _house.Show();
    }
}
```

具体装饰者（装饰后房子类）
```
public class ModelHouse : DecoratorHouse
{
    public ModelHouse(AbstractHouse house) : base(house)
    {
    }

    public override void Show()
    {
        base.Show();
        ShowDetail();
    }

    /// <summary>
    /// 展示样板房细节
    /// </summary>
    private void ShowDetail()
    {
        Console.WriteLine(@"
* 首先，您看到的是我们大概5平方的简单实用的入户花园。
* 样板间的整体按欧式风格装修，精致温馨。
* 进门右看是我们的餐厨一体化设计，客厅与餐厅动线相连，扩大了整个的空间视野。
* 与客厅无缝连接的是超大的观景阳台，东南朝向，阳光充沛。
* 动静分离的设计，将客厅与卧室进行有效的分离，保证了私密性及舒适度。
* 主卧的落地窗设计，提供了足够的室内的采光度。
* 主卧旁边的是干湿分离的卫生间。
* 再旁边就是两个紧挨的房间，可按居家情况设计为儿童房、老人房或书房。");
    }
}
```

## 优点
**低耦合**：装饰类和被装饰类可以独立变化，互不影响。  
**灵活性**：可以动态地添加或撤销功能。  
**替代继承**：提供了一种继承之外的扩展对象功能的方式。

## 缺点
**复杂性**：多层装饰可能导致系统复杂性增加。

## 使用场景
在需要动态扩展功能时，考虑使用装饰器模式。  
保持装饰者和具体组件的接口一致，以确保灵活性。

## 注意事项
装饰器模式可以替代继承，但应谨慎使用，避免过度装饰导致系统复杂。