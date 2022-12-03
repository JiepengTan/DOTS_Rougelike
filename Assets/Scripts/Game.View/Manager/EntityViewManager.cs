using System.Collections.Generic;
using UnityEngine;

namespace GamesTan.Game.View {
    public class EntityViewManager : BaseManager<EntityViewManager> {

        private Dictionary<long, GameEntityView> _id2View = new Dictionary<long, GameEntityView>();

        public void OnCreateEntity(GameObject go, long entityId) {
            var comp = go.AddComponent<GameEntityView>();
            comp.EntityId = entityId;
            _id2View[entityId] = comp;
        }
        public void OnDestroyEntity(long entityId) {
            if (_id2View.TryGetValue(entityId, out var binder)) {
                GameObject.Destroy(binder.gameObject);
            }
        }

        public GameEntityView GetEntityView(long entityId) {
            if (_id2View.TryGetValue(entityId, out var binder)) {
                return binder;
            }

            return null;
        }

        public void DestroyAll() {
            foreach (var pair in _id2View) {
                var view = pair.Value;
                if (view != null) {
                    GameObject.Destroy(view.gameObject);
                }
            }
            _id2View.Clear();
        }
    }
}