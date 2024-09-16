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