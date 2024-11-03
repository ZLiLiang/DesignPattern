Console.WriteLine("========== SimpleImplement ==========");
// 创建股票对象（被观察者）
ObserverPattern.SimpleImplement.Stock stock1 = new ObserverPattern.SimpleImplement.Stock();

// 创建观察者（投资者）
ObserverPattern.SimpleImplement.Investor investor1 = new ObserverPattern.SimpleImplement.Investor("Alice");
ObserverPattern.SimpleImplement.Investor investor2 = new ObserverPattern.SimpleImplement.Investor("Bob");

// 注册观察者
stock1.RegisterObserver(investor1);
stock1.RegisterObserver(investor2);

// 更新股票价格，触发通知
stock1.Price = 120.50m;
stock1.Price = 125.00m;

// 移除一个观察者
stock1.RemoveObserver(investor1);

// 再次更新股票价格，只有 Bob 收到通知
stock1.Price = 130.00m;

Console.WriteLine("               ");

Console.WriteLine("========== DelegateImplement ==========");

// 创建股票对象
ObserverPattern.DelegateImplement.Stock stock2 = new ObserverPattern.DelegateImplement.Stock();

// 创建观察者（投资者）
ObserverPattern.DelegateImplement.Investor investor3 = new ObserverPattern.DelegateImplement.Investor("Cason");
ObserverPattern.DelegateImplement.Investor investor4 = new ObserverPattern.DelegateImplement.Investor("Cristiana");

// 注册投资者的回调方法到 PriceChanged 事件
stock2.PriceChanged += investor3.OnStockPriceChanged;
stock2.PriceChanged += investor4.OnStockPriceChanged;

// 更新股票价格，触发通知
stock2.Price = 120.50m;
stock2.Price = 125.00m;

// 移除一个观察者的订阅
stock2.PriceChanged -= investor3.OnStockPriceChanged;

// 再次更新股票价格，只有 Bob 收到通知
stock2.Price = 130.00m;

Console.ReadLine();