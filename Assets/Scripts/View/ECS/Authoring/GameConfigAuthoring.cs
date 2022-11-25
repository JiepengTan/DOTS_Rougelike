using System.Collections.Generic;
using UnityEngine;

namespace GamesTan.ECS.Game {
    public partial class GameConfigAuthoring : MonoBehaviour,IAuthoring {
        public List<GameObject> EnemyPrefabs = new List<GameObject>();
        public List<GameObject> WallPrefabs = new List<GameObject>();
        public List<GameObject> FloorPrefabs = new List<GameObject>();
        public List<GameObject> FoodPrefabs = new List<GameObject>();
        public GameObject PlayerPrefab;
        public GameObject ExitPrefab;

        public Vector2Int MapSize = new Vector2Int(10, 10);
        public uint RandomSeed;
    }
}