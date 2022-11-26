using Unity.Entities;

namespace GamesTan.ECS.Game {
    public interface IPrefabBufferElement :IBufferElementData{
        public Entity Prefab { get;  set; }
    }
    
}