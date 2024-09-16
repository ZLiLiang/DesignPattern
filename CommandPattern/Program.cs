using CommandPattern;

Command forceCommand = new ForceCommand();
Invoker invoker1 = new Invoker(forceCommand);
invoker1.InovkerName = "Jack";
invoker1.Invoke();

Console.WriteLine("-------------------------------");

Command peaceCommand = new PeaceCommand();
Invoker invoker2 = new Invoker(peaceCommand);
invoker2.InovkerName = "Tom";
invoker2.Invoke();

Console.ReadLine();