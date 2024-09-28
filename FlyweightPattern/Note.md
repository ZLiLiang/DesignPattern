# ��Ԫģʽ
��Ҫ���ڼ��ٴ���������������Լ����ڴ�ռ�ú�������ܡ�

ʵ�壨�ʼ��ࣩ
```
public class Email
{
    public string Receiver { get; set; }
    public string Sender { get; }
    public string Subject { get; }
    public string Template { get; }
    public string Signature { get; }

    public Email(string sender, string subject, string template, string signature)
    {
        Sender = sender;
        Subject = subject;
        Template = template;
        Signature = signature;
    }
}
```

������Ԫ(�ʼ�ģ�幤����)
```
public static class EmailTemplateFactory
{
    /// <summary>
    /// Ԥ��ģ��
    /// </summary>
    private static readonly Dictionary<string, string> SubjectAndContentMapping = new Dictionary<string, string>
    {
        {
                "���޸�©��֪ͨ",
                @"�𾴵��û����ƶܼ�⵽���ķ���������phpwindv9��������GET��CSRF����ִ��©����
                  Ŀǰ��Ϊ���з���©�������������ƶܿ���̨����һ���޸���Ϊ�����©�����ڿ����ã�
                  �����������޸���©���������Ե���˴���¼�ƶ� - ��������ȫ(����ʿ)����̨���в鿴���޸�"
            },
            {
                "������ECS��������֪ͨ",
                @"����1̨�Ʒ�����ECS����һ�ܺ���ʽ���ڡ�δ���ѵ��Ʒ�����ECSʵ�����ں�ֹͣ����
                  ���ں�����Ϊ������7�죬����δ����ʵ������̻ᱻ�ͷţ����ݲ��ɻָ���
                  Ϊ�˱�֤���ķ����������У��뼰ʱ���ѡ�"
            },
            {"�����ƹ���ͨ��", "���ķ��������ڹ��ϣ������˽⣡"},
            {"����������֪ͨ", "���ǽ��԰����ƽ�������������ڷ��������ݲ������������֪Ϥ��"}
    };

    /// <summary>
    /// ��������
    /// </summary>
    static readonly ConcurrentDictionary<string, Email> EmailTemplates = new ConcurrentDictionary<string, Email>();

    /// <summary>
    /// ���������ȡģ��
    /// </summary>
    /// <param name="subject"></param>
    /// <returns></returns>
    public static Email GetTemplate(string subject)
    {
        Email email = null;
        if (!EmailTemplates.ContainsKey(subject))
        {
            string template;
            SubjectAndContentMapping.TryGetValue(subject, out template);
            email = new Email("system@notice.aliyun.com", subject, string.IsNullOrWhiteSpace(template) ? subject : template, "�����Ƽ��㹫˾");
            EmailTemplates.TryAdd(subject, email);
        }
        else
        {
            EmailTemplates.TryGetValue(subject, out email);
        }

        return email;
    }
}
```

## �ŵ�
**�����ڴ�����**��ͨ��������󣬼������ڴ��ж����������  
**���Ч��**�������˶��󴴽���ʱ�䣬�����ϵͳЧ�ʡ�

## ȱ��
**����ϵͳ���Ӷ�**����Ҫ�����ڲ�״̬���ⲿ״̬����������ƺ�ʵ�ֵĸ����ԡ�  
**�̰߳�ȫ����**������ⲿ״̬�����������ܻ������̰߳�ȫ���⡣

## ʹ�ó���
�ڴ����������ƶ���ʱ����ʹ����Ԫģʽ��  
ȷ����Ԫ������ڲ�״̬�ǹ���ģ����ⲿ״̬�Ƕ����ڶ���ġ�

## ע������
**״̬����**����ȷ�����ڲ�״̬���ⲿ״̬�����������  
**��Ԫ����**��ʹ����Ԫ���������ƶ���Ĵ����͸��ã�ȷ�������һ���Ժ������ԡ�