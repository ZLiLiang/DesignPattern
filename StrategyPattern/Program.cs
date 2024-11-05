using StrategyPattern;

Console.WriteLine("=== OperationAdd ===");
OperationContext context = new OperationContext(new OperationAdd());
Console.WriteLine($"10 + 5 = {context.ExecuteStrategy(10, 5)}");

Console.WriteLine("=== OperationSubtract ===");
context = new OperationContext(new OperationSubtract());
Console.WriteLine($"10 - 5 = {context.ExecuteStrategy(10, 5)}");

Console.ReadLine();