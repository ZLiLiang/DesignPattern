namespace DecoratorPattern;

/// <summary>
/// 未装修房 -- 毛坯房
/// </summary>
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
