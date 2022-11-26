
using Unity.Entities;
using UnityEngine;

namespace GamesTan.ECS.Game.View {
    public class GameController : MonoBehaviour {
        public bool useSeed = false;
        public uint randomSeed = 42;


        public CLevelLogicConfig Config;
        void Start() {
            Debug.Log("Starting GameController using seed " +randomSeed);
            Contexts.GameData.DoAwake();
            Contexts.GameData.RndSeed = randomSeed;
            LoadLevel(Config);
        }


        void LoadLevel(CLevelLogicConfig config) {
            var em = World.DefaultGameObjectInjectionWorld.EntityManager;
            var entity = em.CreateEntity(typeof(CLevelLogicConfig));
            em.SetComponentData(entity,config );
            
        }
        

    }
}
