# ������ģʽ
��װһЩ������ĳ�����ݽṹ�еĸ�Ԫ�صĲ������������ڲ��ı����ݽṹ��ǰ���¶�����������ЩԪ�ص��µĲ�����

�����ߣ������߽ӿڣ�
```
public interface IVisitor
{
    public abstract void Visit(SaleOrder saleOrder);
    public abstract void Visit(ReturnOrder returnOrder);
}
```

��������ߣ�����Ա���շ���Ա�ࣩ
```
public class Picker : IVisitor
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Visit(SaleOrder saleOrder)
    {
        Console.WriteLine($"��ʼΪ���۶�����{saleOrder.Id}���������ۼ������");
        foreach (var item in saleOrder.OrderItems)
        {
            Console.WriteLine($"��{item.Product.Name}����Ʒ* {item.Qty}");
        }

        Console.WriteLine($"������{saleOrder.Id}�������ϣ�");

        Console.WriteLine("==========================");
    }

    public void Visit(ReturnOrder returnOrder)
    {
        Console.WriteLine($"��ʼΪ�˻�������{returnOrder.Id}�������˻��������");
        foreach (var item in returnOrder.OrderItems)
        {
            Console.WriteLine($"��{item.Product.Name}����Ʒ* {item.Qty}");
        }

        Console.WriteLine($"�˻�������{returnOrder.Id}���˻������ϣ�", returnOrder.Id);
        Console.WriteLine("==========================");
    }
}

public class Distributor : IVisitor
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Visit(SaleOrder saleOrder)
    {
        Console.WriteLine($"��ʼΪ���۶�����{saleOrder.Id}�����з�������", saleOrder.Id);

        Console.WriteLine($"һ�����{saleOrder.OrderItems.Sum(line => line.Qty)}����Ʒ��");
        Console.WriteLine($"�ջ��ˣ�{saleOrder.Customer.RealName}");
        Console.WriteLine($"��ϵ�绰��{saleOrder.Customer.Phone}");
        Console.WriteLine($"�ջ���ַ��{saleOrder.Customer.Address}");
        Console.WriteLine($"�������룺{saleOrder.Customer.Zip}");

        Console.WriteLine($"������{saleOrder.Id}��������ϣ�");
        Console.WriteLine("==========================");
    }

    public void Visit(ReturnOrder returnOrder)
    {
        Console.WriteLine($"�յ����ԡ�{returnOrder.Customer.NickName}�����˻�������{returnOrder.Id}���������˻��ջ�����");

        foreach (var item in returnOrder.OrderItems)
        {
            Console.WriteLine($"��{item.Product.Name}����Ʒ* {item.Qty}");
        }

        Console.WriteLine($"�˻�������{returnOrder.Id}���ջ�������ϣ�");
        Console.WriteLine("==========================");
    }
}
```

Ԫ�أ������ࣩ
```
public abstract class Order
{
    public int Id { get; set; }

    public Customer Customer { get; set; }

    public DateTime CreatorDate { get; set; }

    /// <summary>
    /// ����Ʒ��
    /// </summary>
    public List<OrderLine> OrderItems { get; set; }

    public abstract void Accept(IVisitor visitor);

} 
```

����Ԫ�أ����۵����˻����ࣩ
```
public class SaleOrder : Order
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class ReturnOrder : Order
{
    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
```

����ṹ�����������ࣩ
```
public class OrderCenter : List<Order>
{
    public void Accept(IVisitor visitor)
    {
        var iterator = this.GetEnumerator();

        while (iterator.MoveNext())
        {
            iterator.Current.Accept(visitor);
        }
    }

}
```

## �ŵ�
**��һְ��ԭ��**��������ģʽ���ϵ�һְ��ԭ��ÿ����ֻ����һ��ְ��  
**��չ��**������Ϊ���ݽṹ����µĲ�����  
**�����**�������߿��Զ��������ݽṹ�仯��

## ȱ��
**Υ��������ԭ��**��Ԫ����Ҫ������߹������ڲ���Ϣ��  
**Ԫ�������Ա��**��Ԫ������Ҫά��������ߵļ��ݡ�  
**����������**��������ģʽ�����ھ���������ǽӿڣ�Υ������������ԭ��  

## ʹ�ó���
- ������ṹ�ȶ�������Ҫ�����϶�������²���ʱ������ʹ�÷�����ģʽ��
- ����Ҫ�������"��Ⱦ"������ʱ��ʹ�÷�����ģʽ��װ������

## ע������
- ������ģʽ�������ڹ���ͳһ���籨�����ɡ��û�������ʾ���������͹������ȡ�