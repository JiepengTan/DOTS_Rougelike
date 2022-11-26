using System.Collections.Generic;
using UnityEngine;

namespace GamesTan.ECS.Game {
    public partial class LevelConfigAuthoring : MonoBehaviour,IAuthoring {
        public List<GameObject> OutWallPrefabs = new List<GameObject>();
        public List<GameObject> FloorPrefabs = new List<GameObject>();
        public GameObject ExitPrefab;

        public Vector2Int MapSize = new Vector2Int(10, 10);
        public uint RandomSeed;
    }
}