﻿using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace GamesTan.ECS.Game {
    public partial class LoadLevelLogicAuthoring : MonoAuthoring {
        public List<GameObject> PrefabPlayer = new List<GameObject>();
        public List<GameObject> PrefabWall = new List<GameObject>();
        public List<GameObject> PrefabEnemy = new List<GameObject>();
        public List<GameObject> PrefabItem = new List<GameObject>();
        
    }
    
    public partial class BkLevelLogicConfig : Baker<LoadLevelLogicAuthoring> {
        public override void Bake(LoadLevelLogicAuthoring authoring) {
            AddComponent(GetEntity(), new ComponentTypeSet(
                new ComponentType[] {
                    typeof(CdTagLoadLevel),
                    typeof(CdPrefabPlayer),
                    typeof(CdPrefabWall),
                    typeof(CdPrefabEnemy),
                    typeof(CdPrefabItem),
                }));
            this.CreateBuffer<CdPrefabPlayer>(authoring.PrefabPlayer);
            this.CreateBuffer<CdPrefabWall>(authoring.PrefabWall);
            this.CreateBuffer<CdPrefabEnemy>(authoring.PrefabEnemy);
            this.CreateBuffer<CdPrefabItem>(authoring.PrefabItem);
        }
    }
}