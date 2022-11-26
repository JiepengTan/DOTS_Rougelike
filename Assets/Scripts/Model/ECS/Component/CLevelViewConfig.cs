using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Serialization;
using Unity.Mathematics;

namespace GamesTan.ECS.Game {

    

    public partial struct CLevelViewConfig : IComponentData {
        public Entity ExitPrefab;
        public uint RndSeed;
    }
}