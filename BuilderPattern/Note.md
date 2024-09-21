# ������ģʽ
��һ�����Ӷ���Ĺ��������ı�ʾ���룬ʹ��ͬ���Ĺ������̿��Դ�����ͬ�ı�ʾ��

��Ʒ�������ࣩ
```
public class Computer
{
    /// <summary>
    /// Ʒ��
    /// </summary>
    public string Band { get; set; }

    /// <summary>
    /// ��������б�
    /// </summary>
    private List<string> assemblyParts = [];

    /// <summary>
    /// ��װ����
    /// </summary>
    /// <param name="partName">��������</param>
    public void AssemblePart(string partName)
    {
        this.assemblyParts.Add(partName);
    }

    public void ShowSteps()
    {
        Console.WriteLine($"��ʼ��װ��{Band}������:");

        foreach (var part in assemblyParts)
        {
            Console.WriteLine($"��װ��{part}��;");
        }

        Console.WriteLine($"��װ��{Band}��������ϣ�");
    }
}
```

�������ߣ����������ࣩ
```
public abstract class Builder
{
    /// <summary>
    /// ��װ����
    /// </summary>
    protected abstract void BuildMainFramePart();

    /// <summary>
    /// ��װ��ʾ��
    /// </summary>
    protected abstract void BuildScreenPart();

    /// <summary>
    /// ��װ�����豸������
    /// </summary>
    protected abstract void BuildInputPart();

    /// <summary>
    /// ��ȡ��װ����
    /// �ɾ������װ�������װ˳��
    /// </summary>
    /// <returns></returns>
    public abstract Computer BuildComputer();
}
```

��Ʒ���彨���ߣ����ա������������ࣩ
```
public class HpBuilder : Builder
{
    private readonly Computer _hpComputer;

    public HpBuilder()
    {
        _hpComputer = new() { Band = "����" };
    }

    protected override void BuildMainFramePart()
    {
        _hpComputer.AssemblePart("����");
    }

    protected override void BuildScreenPart()
    {
        _hpComputer.AssemblePart("��ʾ��");
    }

    protected override void BuildInputPart()
    {
        _hpComputer.AssemblePart("����");
    }

    /// <summary>
    /// �����������װ����
    /// </summary>
    /// <returns></returns>
    public override Computer BuildComputer()
    {
        this.BuildMainFramePart();
        this.BuildScreenPart();
        this.BuildInputPart();

        return _hpComputer;
    }
}
```

```
public class DellBuilder : Builder
{
    private readonly Computer _dellComputer;

    public DellBuilder()
    {
        _dellComputer = new() { Band = "����" };
    }

    protected override void BuildMainFramePart()
    {
        _dellComputer.AssemblePart("����");
    }

    protected override void BuildScreenPart()
    {
        _dellComputer.AssemblePart("��ʾ��");
    }

    protected override void BuildInputPart()
    {
        _dellComputer.AssemblePart("����");
    }

    public override Computer BuildComputer()
    {
        this.BuildMainFramePart();
        this.BuildScreenPart();
        this.BuildInputPart();

        return _dellComputer;
    }
}
```

ָ���ߣ��������ࣩ
```
public class Director
{
    public Computer Construct(Builder builder)
    {
        return builder.BuildComputer();
    }
}
```

## �ŵ�
���빹�����̺ͱ�ʾ��ʹ�ù������̸��������Թ�����ͬ�ı�ʾ��  
���Ը��õؿ��ƹ������̣����ؾ��幹��ϸ�ڡ�  
���븴���Ըߣ������ڲ�ͬ�Ĺ����������ظ�ʹ����ͬ�Ľ����ߡ�

## ȱ��
�����Ʒ�����Խ��٣�������ģʽ���ܻᵼ�´������ࡣ  
������ϵͳ����Ͷ���������

## ʹ�ó���
��Ҫ���ɵĶ�����и��ӵ��ڲ��ṹ��  
��Ҫ���ɵĶ����ڲ������໥������

## ע������
�빤��ģʽ�������ǣ�������ģʽ���ӹ�ע�����װ���˳��