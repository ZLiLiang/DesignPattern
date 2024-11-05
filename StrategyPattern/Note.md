# 策略模式
定义一组算法，将每个算法都封装起来，并且使它们之间可以互换。

抽象策略（操作策略接口）
```
public interface IOperationStrategy
{
    public int DoOperation(int num1, int num2);
}
```

具体策略（加操作、减操作类）
```
public class OperationAdd : IOperationStrategy
{
    public int DoOperation(int num1, int num2)
    {
        return num1 + num2;
    }
}

public class OperationSubtract : IOperationStrategy
{
    public int DoOperation(int num1, int num2)
    {
        return num1 - num2;
    }
}
```

上下文（操作上下文类）
```
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
```

## 优点
**算法切换自由**：可以在运行时根据需要切换算法。  
**避免多重条件判断**：消除了复杂的条件语句。  
**扩展性好**：新增算法只需新增一个策略类，无需修改现有代码。

## 缺点
**策略类数量增多**：每增加一个算法，就需要增加一个策略类。  
**所有策略类都需要暴露**：策略类需要对外公开，以便可以被选择和使用。

## 使用场景
- 当系统中有多种算法或行为，且它们之间可以相互替换时，使用策略模式。  
- 当系统需要动态选择算法时，策略模式是一个合适的选择。

## 注意事项
- 如果系统中策略类数量过多，考虑使用其他模式或设计技巧来解决类膨胀问题。