# 桥接模式
将抽象和实现解耦，使得两者可以独立地变化。

原始抽象类（项目抽象类）
```
public abstract class Project
{
    /// <summary>
    /// 项目名称
    /// </summary>
    public string ProjectName { get; set; }

    protected Project(string projectName)
    {
        ProjectName = projectName;
    }

    /// <summary>
    /// 需求分析
    /// </summary>
    public abstract void AnalyzeRequirement();

    /// <summary>
    /// 产品设计
    /// </summary>
    public abstract void DesignProduct();

    /// <summary>
    /// 制定计划
    /// </summary>
    public abstract void MakePlan();

    /// <summary>
    /// 任务分解
    /// </summary>
    public abstract void ScheduleTask();

    /// <summary>
    /// 进度把控
    /// </summary>
    public abstract void ControlProcess();

    /// <summary>
    /// 产品发布
    /// </summary>
    public abstract void ReleaseProduct();

    /// <summary>
    /// 后期运维
    /// </summary>
    public abstract void MaintainProduct();
}
```

解耦抽象类（管理抽象类）
```
public abstract class Manager
{
    protected Project CurrentProject { get; }

    protected Manager(Project currentProject)
    {
        CurrentProject = currentProject;
    }

    /// <summary>
    /// 制定计划
    /// </summary>
    public abstract void SchedulePlan();

    /// <summary>
    /// 任务分配
    /// </summary>
    public abstract void AssignTasks();

    /// <summary>
    /// 进度把控
    /// </summary>
    public abstract void ControlProcess();

    /// <summary>
    /// 项目管理
    /// </summary>
    public virtual void ManageProject()
    {
        this.SchedulePlan();
        this.AssignTasks();
        this.ControlProcess();
    }
}
```

实现解耦抽象类（项目管理类）
```
public class ProjectManager : Manager
{
    public ProjectManager(Project currentProject) : base(currentProject)
    {
    }

    public override void SchedulePlan()
    {
        base.CurrentProject.MakePlan();
    }

    public override void AssignTasks()
    {
        base.CurrentProject.ScheduleTask();
    }

    public override void ControlProcess()
    {
        base.CurrentProject.ControlProcess();
    }

    public override void ManageProject()
    {
        Console.WriteLine($"项目经理负责【{base.CurrentProject.ProjectName}】：");
        base.ManageProject();
    }
}
```

实现解耦抽象类（产品管理类）
```
public class ProductManger : Manager
{
    public ProductManger(Project currentProject) : base(currentProject)
    {
    }

    public override void SchedulePlan()
    {
        base.CurrentProject.MakePlan();
    }

    public override void AssignTasks()
    {
        base.CurrentProject.ScheduleTask();
    }

    public override void ControlProcess()
    {
        base.CurrentProject.ControlProcess();
    }

    public void AnalyseRequirement()
    {
        base.CurrentProject.AnalyzeRequirement();
    }

    public void DesignProduct()
    {
        base.CurrentProject.DesignProduct();
    }

    public override void ManageProject()
    {
        Console.WriteLine($"产品经理负责【{base.CurrentProject.ProjectName}】：");
        this.AnalyseRequirement();
        this.DesignProduct();
        base.ManageProject();
    }
}
```

## 优点
**抽象与实现分离**：提高了系统的灵活性和可维护性。  
**扩展能力强**：可以独立地扩展抽象和实现。  
**实现细节透明**：用户不需要了解实现细节。

## 缺点
**理解与设计难度**：桥接模式增加了系统的理解与设计难度。  
**聚合关联**：要求开发者在抽象层进行设计与编程。

## 使用场景
当系统需要在抽象化角色和具体化角色之间增加灵活性时，考虑使用桥接模式。  
对于不希望使用继承或因多层次继承导致类数量急剧增加的系统，桥接模式特别适用。  
当一个类存在两个独立变化的维度，且这两个维度都需要扩展时，使用桥接模式。

## 注意事项
桥接模式适用于两个独立变化的维度，确保它们可以独立地扩展和变化。