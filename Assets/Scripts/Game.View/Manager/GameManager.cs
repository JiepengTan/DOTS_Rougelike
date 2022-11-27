using System;
using GamesTan.ECS.Game;
using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;

namespace GamesTan.Game.View {
    public class GameManager : BaseMonoManager<GameManager> {
        public bool useSeed = false;
        public uint randomSeed = 42;


        public CdLevelLogicConfig Config;

        void Start() {
            Debug.Log("Starting GameController using seed " + randomSeed);
            Contexts.ResetId();
            Contexts.ResetRandom(randomSeed);
        }


        public void LoadLevel(CdLevelLogicConfig config) {
            var em = World.DefaultGameObjectInjectionWorld.EntityManager;
            var entity = SystemAPI.GetSingletonEntity<CdLevelLogicConfig>();
            em.SetComponentData(entity, config);
            em.SetComponentEnabled<CdTagLoadLevel>(entity, true);
        }
    }
}