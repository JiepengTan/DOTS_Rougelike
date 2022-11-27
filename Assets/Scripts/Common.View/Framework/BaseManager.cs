using UnityEngine;

namespace GamesTan.Game.View {
    public abstract partial class BaseManager<T> where T : new(){
        private static T _Instance;
        public static T Instance {
            get {
                if (_Instance == null) {
                    _Instance = new T();
                }
                return _Instance;
            }
        }

        public virtual void DoAwake() {
        }
    }
}