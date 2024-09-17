namespace CompositePattern;

/// <summary>
/// 组织架构
/// </summary>
public abstract class Organization
{
    /// <summary>
    /// 成员姓名
    /// </summary>
    public string MemberName { get; set; }

    /// <summary>
    /// 成员职位
    /// </summary>
    public string MemberPosition { get; set; }

    /// <summary>
    /// 直接上级
    /// </summary>
    public Organization ParentNode { get; set; }

    public void Display()
    {
        var basicInfo = $"姓名：{MemberName},职位：{MemberPosition}";
        var parentInfo = ParentNode == null
            ? ""
            : $"，直接上级：『姓名：{ParentNode.MemberName},职位：{ParentNode.MemberPosition}』";
        Console.WriteLine($"{basicInfo}{parentInfo}");
    }
}
