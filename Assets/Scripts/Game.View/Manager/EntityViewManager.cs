using System.Collections.Generic;
using UnityEngine;

namespace GamesTan.Game.View {
    public class EntityViewManager : BaseManager<EntityViewManager> {

        private Dictionary<long, EntityViewBinder> _id2View = new Dictionary<long, EntityViewBinder>();

        public void OnCreateEntity(GameObject go, long entityId) {
            var comp = go.AddComponent<EntityViewBinder>();
            comp.EntityId = entityId;
        }
        public void OnDestroyEntity(long entityId) {
            if (_id2View.TryGetValue(entityId, out var binder)) {
                GameObject.Destroy(binder.gameObject);
            }
        }
    }
}