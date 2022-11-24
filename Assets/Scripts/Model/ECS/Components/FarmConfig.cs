using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace GamesTan.ECS.Game  {

    public struct FarmConfig : IComponentData {
        public Entity FarmerPrefab;
        public Entity RockPrefab;
        public Entity DronePrefab;
        public Entity FarmPrefab;
        public Entity PlantPrefab;
        public Entity Plant2Prefab;

        public int InitFarmerCount;
        public int2 MapSize;
        public uint RandomSeed;
    }
}