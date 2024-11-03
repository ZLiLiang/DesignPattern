# 原型模式
用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象。
在 .NET 中，使用 Object 类的 MemberwiseClone() 方法实现浅拷贝，或通过序列化实现深拷贝。

具体原型类（邮件类）
```
public class Email : ICloneable
{
    public string Receiver { get; set; }
    public string Sender { get; set; }
    public string Subject { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }
    public string Footer { get; set; }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}
```

## 优点
- 性能提高。  
- 避免构造函数的约束。

## 缺点
- 配备克隆方法需要全面考虑类的功能，对已有类可能较难实现，特别是处理不支持串行化的间接对象或含有循环结构的引用时。  
- 必须实现 Cloneable 接口。

## 使用场景
- 资源优化。  
- 类初始化需要消耗大量资源（如数据、硬件资源）。  
- 性能和安全要求高的场景。  
- 通过 new 创建对象需要复杂的数据准备或访问权限时。  
- 一个对象需要多个修改者。  
- 对象需提供给其他对象访问并可能被各个调用者修改时。  
- 通常与工厂方法模式一起使用，通过 clone 创建对象，然后由工厂方法提供给调用者。

## 注意事项
与直接实例化类创建新对象不同，原型模式通过拷贝现有对象生成新对象。浅拷贝通过实现 Cloneable 实现，深拷贝通过实现 Serializable 读取二进制流实现。