using CompositePattern;

static void DisplayStructureASC(Organization organization)
{
    organization.Display();

    Department department = (Department)organization;

    foreach (var depart in department.GetDepartmentMembers())
    {
        if (depart is not Member)
        {
            DisplayStructureASC(depart);
        }
        else
        {
            depart.Display();
        }
    }
}

static void DisplayStructureDESC(Organization organization)
{
    Department department = (Department)organization;

    foreach (var depart in department.GetDepartmentMembers())
    {
        if (depart is not Member)
        {
            DisplayStructureDESC(depart);
        }
        else
        {
            depart.Display();
        }
    }

    organization.Display();
}

Console.WriteLine("组合模式：");
Console.WriteLine("-------------------");

var organzation = new Department("CEO", "老总");
var developDepart = new Department("研发部经理", "研哥");

organzation.Add(developDepart);

var projectA = new Department("Erp项目组长", "E哥");

developDepart.Add(projectA);

var memberX = new Member { MemberPosition = "开发工程师", MemberName = "开发X" };
var memberY = new Member { MemberPosition = "开发工程师", MemberName = "开发Y" };
var memberZ = new Member { MemberPosition = "测试工程师", MemberName = "测试Z" };

projectA.Add(memberX);
projectA.Add(memberY);
projectA.Add(memberZ);

Console.WriteLine("组合模式：从上往下遍历");
DisplayStructureASC(organzation);

Console.WriteLine("-------------------");
Console.WriteLine();
Console.WriteLine("-------------------");

Console.WriteLine("组合模式：从下往上遍历");
DisplayStructureDESC(organzation);

Console.WriteLine("-------------------");
Console.ReadLine();