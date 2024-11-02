namespace MediatorPattern;

/// <summary>
/// 支付类
/// </summary>
public class Payment
{
    public bool ProcessPayment(decimal amount)
    {
        Random random = new Random();

        return random.Next(1, 100) > 50;
    }
}
