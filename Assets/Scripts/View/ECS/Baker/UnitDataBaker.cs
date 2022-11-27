using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class UnitDataBaker : Baker<BaseUnitAuthoring> {
        public override void Bake(BaseUnitAuthoring authoring) {
            AddComponent(GetEntity(), new ComponentTypeSet(
                new ComponentType[] {
                    typeof(CAssetInfo),
                    typeof(CBaseUnit),
                    typeof(CEntityView),
                    typeof(CEnableView),
                }));
            SetComponent(GetEntity(), new CAssetInfo() {
                AssetId = authoring.AssetId,
                ConfigId = authoring.ConfigId
            });
        }
    }
}