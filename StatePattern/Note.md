# ״̬ģʽ
��һ����������״̬�ı�ʱ������ı���Ϊ���������������ı������ࡣ

�����ģ��ĵ��ࣩ
```
public class Document
{
    private IDocumentState state;

    public Document()
    {
        // ��ʼ״̬Ϊ�ݸ�״̬
        state = new DraftState();
    }

    public void SetState(IDocumentState state)
    {
        this.state = state;
    }

    public void Submit()
    {
        state.Submit(this);
    }

    public void Publish()
    {
        state.Publish(this);
    }
}
```

״̬��״̬�ӿڣ�
```
public interface IDocumentState
{
    void Submit(Document document);
    void Publish(Document document);
}
```

����״̬���ݸ�״̬�����״̬�ͷ���״̬�ࣩ
```
public class DraftState : IDocumentState
{
    public void Submit(Document document)
    {
        Console.WriteLine("�ĵ����ύ��ˡ�");
        document.SetState(new UnderReviewState());
    }

    public void Publish(Document document)
    {
        Console.WriteLine("�ĵ����ܷ������������ύ��ˡ�");
    }
}

public class UnderReviewState : IDocumentState
{
    public void Submit(Document document)
    {
        Console.WriteLine("�ĵ���������У��޷��ٴ��ύ��");
    }

    public void Publish(Document document)
    {
        Console.WriteLine("�ĵ��ѷ�����");
        document.SetState(new PublishedState());
    }
}

public class PublishedState : IDocumentState
{
    public void Submit(Document document)
    {
        Console.WriteLine("�ĵ��ѷ������޷��ύ��ˡ�");
    }

    public void Publish(Document document)
    {
        Console.WriteLine("�ĵ��Ѿ��Ƿ���״̬��");
    }
}
```

## �ŵ�
**��װ״̬ת������**����״̬ת���߼���װ��״̬�����ڲ���  
**������չ**�������µ�״̬�಻��Ӱ�����д��롣  
**����״̬�����Ϊ**�����������ض�״̬��ص���Ϊ���е�һ�����С�  
**���������**������ʹ�ô���������������л���Ϊ��  
**״̬����**�������������Ķ�����ͬһ��״̬����

## ȱ��
**������Ͷ�������**��ÿ��״̬����Ҫһ�������״̬�ࡣ  
**ʵ�ָ���**��ģʽ�ṹ��ʵ����Ը��ӡ�  
**����ԭ��֧�ֲ���**��������״̬���޸�״̬��Ϊ������Ҫ�޸����д��롣  

## ʹ�ó���
- ���������Ϊ��״̬�ı���仯ʱ������ʹ��״̬ģʽ��  
- ״̬ģʽ������������ӵ��������֧��䡣

## ע������
- ״̬ģʽ������״̬�������ޣ�ͨ��������5�����������  
- ����ʹ�ã��Ա���ϵͳ��ù��ڸ��ӡ�