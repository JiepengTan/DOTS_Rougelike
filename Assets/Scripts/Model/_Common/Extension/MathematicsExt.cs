using Unity.Mathematics;
using UnityEngine;

namespace GamesTan.ECS.Game {
    public static class MathematicsExt {
        public static int2 ToInt2(this Vector2Int vec) => new int2(vec.x, vec.y);
        public static int3 ToInt3(this Vector3Int vec) => new int3(vec.x, vec.y,vec.z);
        public static float2 ToFloat2(this Vector2 vec) => new float2(vec.x, vec.y);
        public static float3 ToFloat3(this Vector3 vec) => new float3(vec.x, vec.y,vec.z);

    }
}