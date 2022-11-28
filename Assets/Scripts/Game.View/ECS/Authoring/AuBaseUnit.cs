using Unity.Entities;
using UnityEngine;

namespace GamesTan.ECS.Game {
    public partial class AuBaseUnit : MonoAuthoring {
        public long AssetId;
        public long ConfigId;
        public int Health;
    }
    
    public partial class BkUnitData : Baker<AuBaseUnit> {
        public override void Bake(AuBaseUnit authoring) {
            // 通用控件
            AddComponent(GetEntity(), new ComponentTypeSet(
                new ComponentType[] {
                    // 下上面是生命期
                    typeof(CdTagAwake),
                    typeof(CdTagStart),
                    // view 层相关属性
                    typeof(CdTagBindEntityView),
                }));
            
            // 游戏相关的
            AddComponent(GetEntity(), new ComponentTypeSet(
                new ComponentType[] {
                    typeof(CdUnitConfig),
                    typeof(CdUnitRuntime),
                }));
            SetComponent(GetEntity(), new CdUnitConfig() {
                AssetId = authoring.AssetId,
                ConfigId = authoring.ConfigId,
                Health = authoring.Health
            });
        }
    }
}