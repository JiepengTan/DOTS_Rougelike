using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class BkUnitItem : Baker<AuUnitItem> {
        public override void Bake(AuUnitItem authoring) {
            AddComponent(GetEntity(), new CdUnitItem());
        }
    }
}