using System.Collections.Generic;
using UnityEngine;

namespace GamesTan.ECS.Game {
    public partial class LevelViewConfigAuthoring : MonoAuthoring {
        public List<GameObject> PrefabOutWall = new List<GameObject>();
        public List<GameObject> PrefabFloor = new List<GameObject>();
        public GameObject PrefabExit;

        public Vector2Int MapSize = new Vector2Int(10, 10);
        public uint RandomSeed;
    }
}