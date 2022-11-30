
using System;
using Unity.Entities;
using UnityEngine;

namespace GamesTan.Game.View {
    public class EntityView: MonoBehaviour {
        public long EntityId;

        private Animator anim;
        public void Awake() {
            anim = GetComponentInChildren<Animator>();
        }

        public void UpdatePos(Vector3 pos) {
            transform.position = pos;
        }

        public void ShowAttack(int tick) {
            if (anim != null) {
                anim.SetTrigger("Attack");
                SoundManager.Instance.PlayAudio("scavengers_enemy1",true);
            }
        }
        public void ShowHited(int tick) {
            if (anim != null) {
                anim.SetTrigger("Hited");
            }
        }
    }
}