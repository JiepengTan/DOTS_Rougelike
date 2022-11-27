using System;
using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;

namespace GamesTan.ECS.Game.View {
    public class GameController : MonoBehaviour {
        public bool useSeed = false;
        public uint randomSeed = 42;


        public CdLevelLogicConfig Config;

        void Start() {
            Debug.Log("Starting GameController using seed " + randomSeed);
            Contexts.GameData.DoAwake();
            Contexts.GameData.RndSeed = randomSeed;
        }


        public void LoadLevel(CdLevelLogicConfig config) {
            var em = World.DefaultGameObjectInjectionWorld.EntityManager;
            var entity = SystemAPI.GetSingletonEntity<CdLevelLogicConfig>();
            em.SetComponentData(entity, config);
            em.SetComponentEnabled<CdTagLoadLevel>(entity, true);
        }
    }
}