using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial struct CdPrefabFloor : IECSPrefabBufferElement { public Entity Value; public Entity Prefab { get => Value; set => Value = value; } }
    public partial struct CdPrefabOutWall : IECSPrefabBufferElement { public Entity Value; public Entity Prefab {  get => Value; set => Value = value; } }
}