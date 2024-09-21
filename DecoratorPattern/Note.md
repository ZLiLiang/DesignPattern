# װ��ģʽ

��̬�ظ�һ��������Ӷ����ְ��ͬʱ���ı���ṹ��װ����ģʽ�ṩ��һ����������̳з�ʽ����չ���ܡ�

������������ࣩ
```
public abstract class AbstractHouse
{
    /// <summary>
    /// ���
    /// </summary>
    public double Area { get; set; }

    /// <summary>
    /// ���
    /// </summary>
    public string Specification { get; set; }

    /// <summary>
    /// �۸�
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// ������󷽷�--չʾ
    /// </summary>
    public abstract void Show();
}
```

���������ë�߷����ࣩ
```
public class WithoutDecoratorHouse : AbstractHouse
{
    /// <summary>
    /// ë����������Ҫչʾ
    /// </summary>
    public override void Show()
    {
        Console.WriteLine($"�û���Ϊ{this.Area}�O���������Ϊ{this.Specification}��Ŀǰ����Ϊ{this.Price}Ԫ/�O��");
    }
}
```

����װ���ߣ�����δװ�η����ࣩ
```
public abstract class DecoratorHouse : AbstractHouse
{
    private readonly AbstractHouse _house;

    protected DecoratorHouse(AbstractHouse house)
    {
        _house = house;
    }

    public override void Show()
    {
        _house.Show();
    }
}
```

����װ���ߣ�װ�κ����ࣩ
```
public class ModelHouse : DecoratorHouse
{
    public ModelHouse(AbstractHouse house) : base(house)
    {
    }

    public override void Show()
    {
        base.Show();
        ShowDetail();
    }

    /// <summary>
    /// չʾ���巿ϸ��
    /// </summary>
    private void ShowDetail()
    {
        Console.WriteLine(@"
* ���ȣ��������������Ǵ��5ƽ���ļ�ʵ�õ��뻧��԰��
* ���������尴ŷʽ���װ�ޣ�������ܰ��
* �����ҿ������ǵĲͳ�һ�廯��ƣ�������������������������������Ŀռ���Ұ��
* ������޷����ӵ��ǳ���Ĺ۾���̨�����ϳ���������档
* �����������ƣ������������ҽ�����Ч�ķ��룬��֤��˽���Լ����ʶȡ�
* ���Ե���ش���ƣ��ṩ���㹻�����ڵĲɹ�ȡ�
* �����Աߵ��Ǹ�ʪ����������䡣
* ���Ա߾������������ķ��䣬�ɰ��Ӽ�������Ϊ��ͯ�������˷����鷿��");
    }
}
```

## �ŵ�
**�����**��װ����ͱ�װ������Զ����仯������Ӱ�졣  
**�����**�����Զ�̬����ӻ������ܡ�  
**����̳�**���ṩ��һ�ּ̳�֮�����չ�����ܵķ�ʽ��

## ȱ��
**������**�����װ�ο��ܵ���ϵͳ���������ӡ�

## ʹ�ó���
����Ҫ��̬��չ����ʱ������ʹ��װ����ģʽ��  
����װ���ߺ;�������Ľӿ�һ�£���ȷ������ԡ�

## ע������
װ����ģʽ��������̳У���Ӧ����ʹ�ã��������װ�ε���ϵͳ���ӡ�