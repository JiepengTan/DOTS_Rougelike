using System.Collections.Generic;
using UnityEngine;

namespace GamesTan.ECS.Game.View {
    public class ResourceManager : MonoBehaviour {
        public static ResourceManager Instance { get; private set; }

        public List<GameObject> Prefabs = new List<GameObject>();
        public Dictionary<long, GameObject> id2Prefab = new Dictionary<long, GameObject>();

        private Transform _root;

        private void Awake() {
            Instance = this;
            _root = new GameObject("__EntityRoot").transform;
            foreach (var prefab in Prefabs) {
                var name = prefab.name;
                var strs = name.Split("_");
                if (strs.Length == 1) continue;
                var id = long.Parse(strs[0]);
                id2Prefab[id] = prefab;
            }
        }

        public GameObject CreateInstantiate(long assetId, Vector3 pos) {
            if (id2Prefab.TryGetValue(assetId, out var prefab)) {
                return GameObject.Instantiate(prefab, pos, Quaternion.identity, _root);
            }

            return null;
        }
    }
}