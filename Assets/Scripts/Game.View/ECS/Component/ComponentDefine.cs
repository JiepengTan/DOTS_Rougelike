using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Serialization;
using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    public partial struct CdLevelViewConfig : IECSComponent {
        public uint RndSeed;
    }
    public partial struct CdPrefabFloor : IECSPrefabBufferElement { public Entity Value; public Entity Prefab { get => Value; set => Value = value; } }
    public partial struct CdPrefabOutWall : IECSPrefabBufferElement { public Entity Value; public Entity Prefab {  get => Value; set => Value = value; } }

    public partial struct CdCleanup: IECSCleanupComponent {
        
    }
    public partial struct CdDestroyView: IECSComponent {
        public long EntityId;
    }
}