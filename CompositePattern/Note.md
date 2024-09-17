# 组合模式

将对象组合成树形结构以表示“部分-整体”的层次结构，使得用户对单个对象和组合对象的使用具有一致性。

组件（组织抽象类）
```
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
```

复合节点（部门类）
```
public class Department : Organization
{
    private readonly List<Organization> _organizationsInfo = [];

    public Department(string departmentName, string charge)
    {
        MemberPosition = departmentName;
        MemberName = charge;
    }

    public void Add(Organization organization)
    {
        _organizationsInfo.Add(organization);
        organization.ParentNode = this;
    }

    public void Remove(Organization organization)
    {
        _organizationsInfo.Remove(organization);
    }

    public List<Organization> GetDepartmentMembers()
    {
        return _organizationsInfo;
    }
}
```

叶子节点（成员类）
```
public class Member : Organization
{

}
```