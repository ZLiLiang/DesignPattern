namespace DecoratorPattern;

/// <summary>
/// 装修房
/// </summary>
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
