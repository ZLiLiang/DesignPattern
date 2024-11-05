# ����ģʽ
����һ���㷨����ÿ���㷨����װ����������ʹ����֮����Ի�����

������ԣ��������Խӿڣ�
```
public interface IOperationStrategy
{
    public int DoOperation(int num1, int num2);
}
```

������ԣ��Ӳ������������ࣩ
```
public class OperationAdd : IOperationStrategy
{
    public int DoOperation(int num1, int num2)
    {
        return num1 + num2;
    }
}

public class OperationSubtract : IOperationStrategy
{
    public int DoOperation(int num1, int num2)
    {
        return num1 - num2;
    }
}
```

�����ģ������������ࣩ
```
public class OperationContext
{
    private IOperationStrategy _operationStrategy;

    public OperationContext(IOperationStrategy operationStrategy)
    {
        _operationStrategy = operationStrategy;
    }

    public int ExecuteStrategy(int num1, int num2)
    {
        return _operationStrategy.DoOperation(num1, num2);
    }
}
```

## �ŵ�
**�㷨�л�����**������������ʱ������Ҫ�л��㷨��  
**������������ж�**�������˸��ӵ�������䡣  
**��չ�Ժ�**�������㷨ֻ������һ�������࣬�����޸����д��롣

## ȱ��
**��������������**��ÿ����һ���㷨������Ҫ����һ�������ࡣ  
**���в����඼��Ҫ��¶**����������Ҫ���⹫�����Ա���Ա�ѡ���ʹ�á�

## ʹ�ó���
- ��ϵͳ���ж����㷨����Ϊ��������֮������໥�滻ʱ��ʹ�ò���ģʽ��  
- ��ϵͳ��Ҫ��̬ѡ���㷨ʱ������ģʽ��һ�����ʵ�ѡ��

## ע������
- ���ϵͳ�в������������࣬����ʹ������ģʽ����Ƽ�����������������⡣