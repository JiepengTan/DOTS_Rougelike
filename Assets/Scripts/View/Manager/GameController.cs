using System;
using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;

namespace GamesTan.ECS.Game.View {
    public class GameController : MonoBehaviour {
        public bool useSeed = false;
        public uint randomSeed = 42;


        public CLevelLogicConfig Config;

        void Start() {
            Debug.Log("Starting GameController using seed " + randomSeed);
            Contexts.GameData.DoAwake();
            Contexts.GameData.RndSeed = randomSeed;
        }


        public void LoadLevel(CLevelLogicConfig config) {
            var em = World.DefaultGameObjectInjectionWorld.EntityManager;
            var entity = SystemAPI.GetSingletonEntity<CLevelLogicConfig>();
            em.SetComponentData(entity, config);
            em.SetComponentEnabled<CTagLoadLevel>(entity, true);
        }
    }
}