namespace StrategyPattern;

public class OperationContext
{
    private IOperationStrategy _operationStrategy;

    public OperationContext(IOperationStrategy operationStrategy)
    {
        _operationStrategy = operationStrategy;
    }

    public int ExecuteStrategy(int num1, int num2)
    {
        return _operationStrategy.DoOperation(num1, num2);
    }
}
