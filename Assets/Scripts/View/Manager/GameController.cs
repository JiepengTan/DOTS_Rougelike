
using UnityEngine;

namespace GamesTan.ECS.Game.View {
    public class GameController : MonoBehaviour {
        public bool useSeed = false;
        public int randomSeed = 42;


        void Start() {
            if (useSeed) {
                Random.seed = randomSeed;
            }

            Debug.Log("Starting GameController using seed " + Random.seed);
        }

        void Update() {
            //systems.Execute();
        }

    }
}
