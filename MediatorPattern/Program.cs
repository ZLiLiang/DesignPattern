using MediatorPattern;

Inventory inventory = new Inventory();
Payment payment = new Payment();
Shipping shipping = new Shipping();

IOrderMediator mediator = new OrderMediator(inventory, payment, shipping);

Order order1 = new Order(1, 100.00m);
mediator.ProcessOrder(order1);
Console.WriteLine("===============================");
Order order2 = new Order(2, 50.00m);
mediator.ProcessOrder(order2);

Console.ReadLine();