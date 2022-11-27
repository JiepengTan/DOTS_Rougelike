using UnityEngine;

namespace GamesTan.ECS.Game {
    public partial interface IAuthoring {
    }

    public abstract partial class MonoAuthoring : MonoBehaviour, IAuthoring {
    }
}