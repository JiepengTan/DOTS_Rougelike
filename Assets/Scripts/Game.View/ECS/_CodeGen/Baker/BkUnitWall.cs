using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial class BkUnitWall : Baker<AuUnitWall> {
        public override void Bake(AuUnitWall authoring) {
            AddComponent(GetEntity(), new CdUnitWall(){
            });
        }
    }
}