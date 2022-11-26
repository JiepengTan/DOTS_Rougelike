using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Serialization;
using Unity.Mathematics;

namespace GamesTan.ECS.Game {
    public interface IPrefabBufferElement :IBufferElementData{
        public Entity Prefab{  set; }
    }

    public partial struct CPrefabEnemy : IPrefabBufferElement { public Entity Value; public Entity Prefab { set => Value = value; } }
    public partial struct CPrefabWall : IPrefabBufferElement { public Entity Value; public Entity Prefab { set => Value = value; } }
    public partial struct CPrefabOutWall : IPrefabBufferElement { public Entity Value; public Entity Prefab { set => Value = value; } }
    public partial struct CPrefabFloor : IPrefabBufferElement { public Entity Value; public Entity Prefab { set => Value = value; } }
    public partial struct CPrefabFood : IPrefabBufferElement { public Entity Value; public Entity Prefab { set => Value = value; } }

    public partial struct CTagPlayer : IComponentData { }
    public partial struct CTagExit : IComponentData { }
    public partial struct CTagEnemy : IComponentData { }
    public partial struct CTagFood : IComponentData { }
    public partial struct CTagFloor : IComponentData { }
    public partial struct CTagOutWall : IComponentData { }
    public partial struct CTagWall : IComponentData { }


    public partial struct CLevelConfig : IComponentData {
        public Entity PlayerPrefab;
        public Entity ExitPrefab;

        public int2 MapSize;
        public uint RandomSeed;
    }
}