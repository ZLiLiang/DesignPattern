namespace AdapterPattern;

/// <summary>
/// 充电线 <br/>
/// 最终要适配成的目标角色
/// </summary>
public interface IChargingLine
{
    /// <summary>
    /// 充电方法
    /// </summary>
    void Charging();
}
