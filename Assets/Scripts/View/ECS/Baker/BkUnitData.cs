﻿using Unity.Entities;

namespace GamesTan.ECS.Game {
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