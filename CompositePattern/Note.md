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

## 优点
**简化客户端代码**：客户端可以统一处理所有类型的节点。  
**易于扩展**：可以轻松添加新的叶子类型或树枝类型。

## 缺点
**违反依赖倒置原则**：组件的声明是基于具体类而不是接口，这可能导致代码的灵活性降低。

## 使用场景
在设计时，优先使用接口而非具体类，以提高系统的灵活性和可维护性。  
适用于需要处理复杂树形结构的场景，如文件系统、组织结构等。

## 注意事项
在实现时，确保所有组件都遵循统一的接口，以保持一致性。  
考虑使用工厂模式来创建不同类型的组件，以进一步解耦组件的创建逻辑。