using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Serialization;
using UnityEngine;

namespace GamesTan.ECS.Game {
    public static class EcsViewExt {
        public static NativeArray<Entity> GetEntity<T>(this Baker<T> self,  List<GameObject> prefabs)where T : Component {
            var ary = new NativeArray<Entity>(prefabs.Count,Allocator.Persistent);
            for (int i = 0; i < prefabs.Count; i++) {
                ary[i] =  self.GetEntity(prefabs[i]);
            }
            return ary;
        }
        public static void CreateBuffer<T>(this IBaker self,  List<GameObject> prefabs)where T :unmanaged, IECSPrefabBufferElement {
            var buffer = self.SetBuffer<T>();
            foreach (var prefab in prefabs)
            {
                buffer.Add(new T { Prefab = self.GetEntity(prefab) });
            }
        }
    }
}