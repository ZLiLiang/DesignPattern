# ģ��ģʽ
����һ���������㷨�Ŀ�ܣ�����һЩ�����ӳٵ������С�ʹ��������Բ��ı�һ���㷨�Ľṹ�����ض�����㷨��ĳЩ�ض����衣

�����ࣨ������װ�����ࣩ
```
public abstract class AssembleComputer
{
    /// <summary>
    /// ��װ����
    /// </summary>
    public abstract void BuildMainFramePart();

    /// <summary>
    /// ��װ��ʾ��
    /// </summary>
    public abstract void BuildScreenPart();

    /// <summary>
    /// ��װ�����豸������
    /// </summary>
    public abstract void BuildInputPart();

    /// <summary>
    /// ��װ����
    /// </summary>
    public void Assemble()
    {
        BuildMainFramePart();
        BuildScreenPart();
        BuildInputPart();
    }
}
```

�������ࣨ��װ���յ��ԡ���װ���������ࣩ
```
public class AssembleHpComputer : AssembleComputer
{
    public override void BuildMainFramePart()
    {
        Console.WriteLine("��װHP���Ե�����");
    }

    public override void BuildScreenPart()
    {
        Console.WriteLine("��װHP���Ե���ʾ��");
    }

    public override void BuildInputPart()
    {
        Console.WriteLine("��װHP���Եļ������");
    }
}

public class AssembleDellComputer : AssembleComputer
{
    public override void BuildMainFramePart()
    {
        Console.WriteLine("��װDell���Ե�����");
    }

    public override void BuildScreenPart()
    {
        Console.WriteLine("��װDell���Ե���ʾ��");
    }

    public override void BuildInputPart()
    {
        Console.WriteLine("��װDell���Եļ������");
    }
}
```

## �ŵ�
**��װ���䲿��**���㷨�Ĳ��䲿�ֱ���װ�ڸ����С�  
**��չ�ɱ䲿��**�����������չ���޸��㷨�Ŀɱ䲿�֡�  
**��ȡ��������**�����ٴ����ظ�������ά����

## ȱ��
**����Ŀ����**��ÿ����ͬ��ʵ�ֶ���Ҫһ�����࣬���ܵ���ϵͳ�Ӵ�

## ʹ�ó���
- ���ж�����๲�еķ������߼���ͬʱ������ʹ��ģ�巽��ģʽ��
- ������Ҫ���ӵķ��������Կ�����Ϊģ�巽�������ڸ����С�

## ע������
- Ϊ�˷�ֹ�����޸ģ�ģ�巽��ͨ��ʹ��final�ؼ������Σ����ⱻ������д��