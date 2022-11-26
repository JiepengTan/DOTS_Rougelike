using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial struct CPrefabPlayer : IPrefabBufferElement { public Entity Value; public Entity Prefab { get => Value;  set => Value = value; } }
    public partial struct CPrefabWall : IPrefabBufferElement { public Entity Value; public Entity Prefab {get => Value; set => Value = value; } }
    public partial struct CPrefabEnemy : IPrefabBufferElement { public Entity Value; public Entity Prefab {get => Value; set => Value = value; } }
    public partial struct CPrefabItem : IPrefabBufferElement { public Entity Value; public Entity Prefab {get => Value; set => Value = value; } }
}