using Unity.Entities;
using UnityEngine;

namespace GamesTan.ECS.Game {
    public partial class AuBaseUnit : MonoAuthoring {
        public long AssetId;
        public long ConfigId;
    }
    
    public partial class BkUnitData : Baker<AuBaseUnit> {
        public override void Bake(AuBaseUnit authoring) {
            AddComponent(GetEntity(), new ComponentTypeSet(
                new ComponentType[] {
                    typeof(CdAssetInfo),
                    typeof(CdBaseUnit),
                    typeof(CdEntityView),
                    typeof(CdEnableView),
                }));
            SetComponent(GetEntity(), new CdAssetInfo() {
                AssetId = authoring.AssetId,
                ConfigId = authoring.ConfigId
            });
        }
    }
}