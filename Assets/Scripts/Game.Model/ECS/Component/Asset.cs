using Unity.Entities;

namespace GamesTan.ECS.Game {
    public partial struct CdPrefabPlayer : IECSPrefabBufferElement {  public Entity Prefab { get ;  set ; } }
    public partial struct CdPrefabWall : IECSPrefabBufferElement {   public Entity Prefab { get ;  set ; } }
    public partial struct CdPrefabEnemy : IECSPrefabBufferElement {   public Entity Prefab { get ;  set ; } }
    public partial struct CdPrefabItem : IECSPrefabBufferElement {   public Entity Prefab { get ;  set ; } }
}