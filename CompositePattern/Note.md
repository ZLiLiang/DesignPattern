# ���ģʽ

��������ϳ����νṹ�Ա�ʾ������-���塱�Ĳ�νṹ��ʹ���û��Ե����������϶����ʹ�þ���һ���ԡ�

�������֯�����ࣩ
```
public abstract class Organization
{
    /// <summary>
    /// ��Ա����
    /// </summary>
    public string MemberName { get; set; }

    /// <summary>
    /// ��Աְλ
    /// </summary>
    public string MemberPosition { get; set; }

    /// <summary>
    /// ֱ���ϼ�
    /// </summary>
    public Organization ParentNode { get; set; }

    public void Display()
    {
        var basicInfo = $"������{MemberName},ְλ��{MemberPosition}";
        var parentInfo = ParentNode == null
            ? ""
            : $"��ֱ���ϼ�����������{ParentNode.MemberName},ְλ��{ParentNode.MemberPosition}��";
        Console.WriteLine($"{basicInfo}{parentInfo}");
    }
}
```

���Ͻڵ㣨�����ࣩ
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

Ҷ�ӽڵ㣨��Ա�ࣩ
```
public class Member : Organization
{

}
```