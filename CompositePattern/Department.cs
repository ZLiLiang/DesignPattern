namespace CompositePattern;

/// <summary>
/// 部门
/// </summary>
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

/// <summary>
/// 员工
/// </summary>
public class Member : Organization
{

}