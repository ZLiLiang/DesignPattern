# �Ž�ģʽ
�������ʵ�ֽ��ʹ�����߿��Զ����ر仯��

ԭʼ�����ࣨ��Ŀ�����ࣩ
```
public abstract class Project
{
    /// <summary>
    /// ��Ŀ����
    /// </summary>
    public string ProjectName { get; set; }

    protected Project(string projectName)
    {
        ProjectName = projectName;
    }

    /// <summary>
    /// �������
    /// </summary>
    public abstract void AnalyzeRequirement();

    /// <summary>
    /// ��Ʒ���
    /// </summary>
    public abstract void DesignProduct();

    /// <summary>
    /// �ƶ��ƻ�
    /// </summary>
    public abstract void MakePlan();

    /// <summary>
    /// ����ֽ�
    /// </summary>
    public abstract void ScheduleTask();

    /// <summary>
    /// ���Ȱѿ�
    /// </summary>
    public abstract void ControlProcess();

    /// <summary>
    /// ��Ʒ����
    /// </summary>
    public abstract void ReleaseProduct();

    /// <summary>
    /// ������ά
    /// </summary>
    public abstract void MaintainProduct();
}
```

��������ࣨ��������ࣩ
```
public abstract class Manager
{
    protected Project CurrentProject { get; }

    protected Manager(Project currentProject)
    {
        CurrentProject = currentProject;
    }

    /// <summary>
    /// �ƶ��ƻ�
    /// </summary>
    public abstract void SchedulePlan();

    /// <summary>
    /// �������
    /// </summary>
    public abstract void AssignTasks();

    /// <summary>
    /// ���Ȱѿ�
    /// </summary>
    public abstract void ControlProcess();

    /// <summary>
    /// ��Ŀ����
    /// </summary>
    public virtual void ManageProject()
    {
        this.SchedulePlan();
        this.AssignTasks();
        this.ControlProcess();
    }
}
```

ʵ�ֽ�������ࣨ��Ŀ�����ࣩ
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
        Console.WriteLine($"��Ŀ������{base.CurrentProject.ProjectName}����");
        base.ManageProject();
    }
}
```

ʵ�ֽ�������ࣨ��Ʒ�����ࣩ
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
        Console.WriteLine($"��Ʒ������{base.CurrentProject.ProjectName}����");
        this.AnalyseRequirement();
        this.DesignProduct();
        base.ManageProject();
    }
}
```

## �ŵ�
**������ʵ�ַ���**�������ϵͳ������ԺͿ�ά���ԡ�  
**��չ����ǿ**�����Զ�������չ�����ʵ�֡�  
**ʵ��ϸ��͸��**���û�����Ҫ�˽�ʵ��ϸ�ڡ�

## ȱ��
**���������Ѷ�**���Ž�ģʽ������ϵͳ�����������Ѷȡ�  
**�ۺϹ���**��Ҫ�󿪷����ڳ�������������̡�

## ʹ�ó���
��ϵͳ��Ҫ�ڳ��󻯽�ɫ�;��廯��ɫ֮�����������ʱ������ʹ���Ž�ģʽ��  
���ڲ�ϣ��ʹ�ü̳л�����μ̳е����������������ӵ�ϵͳ���Ž�ģʽ�ر����á�  
��һ����������������仯��ά�ȣ���������ά�ȶ���Ҫ��չʱ��ʹ���Ž�ģʽ��

## ע������
�Ž�ģʽ���������������仯��ά�ȣ�ȷ�����ǿ��Զ�������չ�ͱ仯��