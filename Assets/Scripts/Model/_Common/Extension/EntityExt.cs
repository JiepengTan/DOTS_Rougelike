using System.Collections.Generic;
using Unity.Entities;
using Unity.Entities.Serialization;
using UnityEngine;

namespace GamesTan.ECS.Game {
    public static class EntityExt {
        public static void AddPrefabs(this ref DynamicBuffer<PrefabBufferElement> buffer, List<GameObject> prefabs) {
            foreach (var prefab in prefabs) {
                buffer.Add(new PrefabBufferElement {Prefab = new EntityPrefabReference(prefab)});
            }
        }
    }
}