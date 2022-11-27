using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    /// <summary>
    /// 游戏输入层数据
    /// View 层不能直接修改Model 层状态，避免引入不确定性
    /// View 层更新数据， Model 层从这里获取 作为输入
    /// </summary>
    public partial class InputLayer {
        
        public static EMoveDir MoveDir;
    }
}