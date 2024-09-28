# 享元模式
主要用于减少创建对象的数量，以减少内存占用和提高性能。

实体（邮件类）
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

具体享元(邮件模板工厂类)
```
public static class EmailTemplateFactory
{
    /// <summary>
    /// 预置模板
    /// </summary>
    private static readonly Dictionary<string, string> SubjectAndContentMapping = new Dictionary<string, string>
    {
        {
                "待修复漏洞通知",
                @"尊敬的用户：云盾检测到您的服务器存在phpwindv9任务中心GET型CSRF代码执行漏洞，
                  目前已为您研发了漏洞补丁，可在云盾控制台进行一键修复。为避免该漏洞被黑客利用，
                  建议您尽快修复该漏洞。您可以点击此处登录云盾 - 服务器安全(安骑士)控制台进行查看和修复"
            },
            {
                "阿里云ECS即将到期通知",
                @"您有1台云服务器ECS将于一周后正式到期。未续费的云服务器ECS实例到期后将停止服务，
                  到期后数据为您保留7天，逾期未续费实例与磁盘会被释放，数据不可恢复。
                  为了保证您的服务正常运行，请及时续费。"
            },
            {"阿里云故障通告", "您的服务器存在故障，请您了解！"},
            {"阿里云升级通知", "我们将对阿里云进行升级，会存在服务器短暂不可用情况，请知悉！"}
    };

    /// <summary>
    /// 定义对象池
    /// </summary>
    static readonly ConcurrentDictionary<string, Email> EmailTemplates = new ConcurrentDictionary<string, Email>();

    /// <summary>
    /// 根据主题获取模板
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
            email = new Email("system@notice.aliyun.com", subject, string.IsNullOrWhiteSpace(template) ? subject : template, "阿里云计算公司");
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

## 优点
**减少内存消耗**：通过共享对象，减少了内存中对象的数量。  
**提高效率**：减少了对象创建的时间，提高了系统效率。

## 缺点
**增加系统复杂度**：需要分离内部状态和外部状态，增加了设计和实现的复杂性。  
**线程安全问题**：如果外部状态处理不当，可能会引起线程安全问题。

## 使用场景
在创建大量相似对象时考虑使用享元模式。  
确保享元对象的内部状态是共享的，而外部状态是独立于对象的。

## 注意事项
**状态分离**：明确区分内部状态和外部状态，避免混淆。  
**享元工厂**：使用享元工厂来控制对象的创建和复用，确保对象的一致性和完整性。