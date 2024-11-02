# 备忘录模式
在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态。这样以后就可将该对象恢复到原先保存的状态。

备忘录（备忘录类）
```
public class ContactMemento
{
    private readonly List<ContactPerson> _backupContactPersons;

    public ContactMemento(List<ContactPerson> backupContactPersons)
    {
        _backupContactPersons = backupContactPersons;
    }

    public List<ContactPerson> GetMemento()
    {
        return _backupContactPersons;
    }
}
```

原发器（手机类）
```
public class Mobile
{
    private List<ContactPerson> _contactPersons;

    public Mobile(List<ContactPerson> contactPersons)
    {
        _contactPersons = contactPersons;
    }

    public List<ContactPerson> GetPhoneBook()
    {
        return _contactPersons;
    }

    /// <summary>
    /// 创建备份
    /// </summary>
    /// <returns></returns>
    public ContactMemento CreateMemento()
    {
        // 进行浅拷贝
        return new ContactMemento(new List<ContactPerson>(_contactPersons));
    }

    /// <summary>
    /// 恢复备份
    /// </summary>
    /// <param name="memento"></param>
    public void RestoreMemento(ContactMemento memento)
    {
        this._contactPersons = memento.GetMemento();
    }

    public void DisplayPhoneBook()
    {
        Console.WriteLine($"共有{_contactPersons.Count}位联系人，联系人列表如下：");
        foreach (var contactPerson in _contactPersons)
        {
            Console.WriteLine($"姓名：{contactPerson.Name}，电话：{contactPerson.PhoneNumber}");
        }
    }
}
```

负责人（备忘录管理类）
```
public class Caretaker
{
    // 存储多个备份
    public Dictionary<string, ContactMemento> ContactMementoes { get; set; }
    public Caretaker()
    {
        ContactMementoes = new Dictionary<string, ContactMemento>();
    }
}
```

## 优点
**提供状态恢复机制**：允许用户方便地回到历史状态。  
**封装状态信息**：用户不需要关心状态的保存细节。

## 缺点
**资源消耗**：如果对象的状态复杂，保存状态可能会占用较多资源。

## 使用场景
在需要保存和恢复数据状态的场景中使用备忘录模式。  
考虑使用原型模式结合备忘录模式，以节约内存。

## 注意事项
为了降低耦合度，应通过备忘录管理类间接管理备忘录对象。  
备忘录模式应谨慎使用，避免过度消耗系统资源。