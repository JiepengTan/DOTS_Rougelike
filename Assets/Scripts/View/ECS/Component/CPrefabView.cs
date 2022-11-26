using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial struct CPrefabFloor : IPrefabBufferElement { public Entity Value; public Entity Prefab { get => Value; set => Value = value; } }
    public partial struct CPrefabOutWall : IPrefabBufferElement { public Entity Value; public Entity Prefab {  get => Value; set => Value = value; } }
}