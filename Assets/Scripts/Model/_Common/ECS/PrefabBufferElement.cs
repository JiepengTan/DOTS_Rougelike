using Unity.Entities;
using Unity.Entities.Serialization;

namespace GamesTan.ECS.Game {
    public struct PrefabBufferElement : IBufferElementData {
        public EntityPrefabReference Prefab;
    }
}