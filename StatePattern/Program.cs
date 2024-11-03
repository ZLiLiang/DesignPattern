using StatePattern;

Document document = new Document();

Console.WriteLine("=== 在草稿状态，尝试提交审核 ===");
document.Submit();

Console.WriteLine("=== 在审核中状态，尝试发布 ===");
document.Publish();

Console.WriteLine("=== 尝试在发布状态提交 ===");
document.Submit();

Console.WriteLine("=== 继续在发布状态发布 ===");
document.Publish();

Console.ReadLine();