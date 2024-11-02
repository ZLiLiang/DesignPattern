namespace MediatorPattern;

/// <summary>
/// 库存类
/// </summary>
public class Inventory
{
    public bool CheckStock(int productId)
    {
        Random random = new Random();

        return random.Next(1, 100) > 50;
    }
}
