using UnityEngine;

namespace GamesTan.Game.View {
    public abstract partial class BaseMonoManager<T>: MonoBehaviour {
        public static T Instance { get; private set; }

        void Awake() {
            Instance = (T)((object)this);
            DoAwake();
        }

        public virtual void DoAwake() {
        }
    }
}