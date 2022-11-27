using System.Collections.Generic;
using UnityEngine;

namespace GamesTan.Game.View {
    public class ResourceManager : BaseMonoManager<ResourceManager> {
        public List<GameObject> Prefabs = new List<GameObject>();
        
        private Dictionary<long, GameObject> _id2Prefab = new Dictionary<long, GameObject>();
        private Transform _root;

        public override void DoAwake() {
            _root = new GameObject("__EntityRoot").transform;
            foreach (var prefab in Prefabs) {
                var name = prefab.name;
                var strs = name.Split("_");
                if (strs.Length == 1) continue;
                var id = long.Parse(strs[0]);
                _id2Prefab[id] = prefab;
            }
        }

        public GameObject CreateInstantiate(long assetId, Vector3 pos) {
            if (_id2Prefab.TryGetValue(assetId, out var prefab)) {
                return GameObject.Instantiate(prefab, pos, Quaternion.identity, _root);
            }
            Debug.LogError(" Can not find Prefab "  +assetId);
            return null;
        }
    }
}