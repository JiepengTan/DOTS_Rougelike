using GamesTan.Game.View;
using Unity.Entities;

namespace GamesTan.ECS.Game.View {
    
    [UpdateInGroup(typeof(ViewInitGroup))]
    [RequireMatchingQueriesForUpdate]
    public partial class SysBindView : GameSystemBase {
        protected override void OnCreate() {
        }

        protected override void OnUpdate() {
            var em = EntityManager;
            //绑定view层，需要运行再主线程上，方便各种 class 操作
            Entities.ForEach((Entity entity, CdUnitConfig configInfo, CdUnitRuntime runtimeInfo, CdNeedBindEntityView enableView) => {
                em.SetComponentEnabled(entity, typeof(CdNeedBindEntityView), false);
                var go = ResourceManager.Instance.CreateInstantiate(configInfo.AssetId,runtimeInfo.Pos.ToVecInt3());
              

                // 各种view 层的操作再这里进行
                // ...
                EntityViewManager.Instance.OnCreateEntity(go,runtimeInfo.EntityId);
            }).Run();
        }
    }
}