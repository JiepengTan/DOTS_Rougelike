namespace GamesTan.ECS.Game {
    /// <summary>
    /// 游戏输出层数据，从ECS 中获取数据，并存储再这里，通过监听者模式 通知view层
    /// View层不直接后去Ecs 中的状态， 由该层封装ECS的实现，让View层拥有完整的OOP体验
    /// </summary>
    public partial class OutputLayer {
    }
    
}