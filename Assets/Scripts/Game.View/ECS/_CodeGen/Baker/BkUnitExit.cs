using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class BkUnitExit : Baker<AuUnitExit> {
        public override void Bake(AuUnitExit authoring) {
            AddComponent(GetEntity(), new CdUnitExit());
        }
    }
}