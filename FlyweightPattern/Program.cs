using FlyweightPattern;

static void SendEmail(Email email)
{
    Console.WriteLine($"主题为『{email.Subject}』的邮件已发送至：{email.Receiver}");
}

for (int i = 0; i < 2000000; i++)
{
    string receiver = $"kehu{i}@qq.com";
    //通过简单工厂维护的对象池获取已经封装好的内部状态的对象。
    var email = EmailTemplateFactory.GetTemplate("阿里云漏洞修复");
    //修改外部状态
    email.Receiver = receiver;
    SendEmail(email);
}