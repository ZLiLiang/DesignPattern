using ChainofResponsibility;

PurchaseBill purchaseBill = new()
{
    BilNo = "CGDD001",
    MaterialName = "惠普电脑",
    Qty = 50,
    Price = 5000,
    BillMaker = new Purchaser("采购员--小责")
    //BillMaker = new Manager("经理--任经理")
    //BillMaker = new CEO("CEO--链总")
};

Console.WriteLine($"创建采购申请单：{purchaseBill.BilNo};申请购买{purchaseBill.Qty}台{purchaseBill.MaterialName}");

purchaseBill.BillMaker.HandleBill(purchaseBill);

Console.ReadLine();