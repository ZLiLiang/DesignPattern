﻿namespace StrategyPattern;

public class OperationSubtract : IOperationStrategy
{
    public int DoOperation(int num1, int num2)
    {
        return num1 - num2;
    }
}
