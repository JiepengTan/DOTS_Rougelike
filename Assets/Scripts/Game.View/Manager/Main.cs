using System;
using UnityEngine;

namespace GamesTan.Game.View {
    public class Main : MonoBehaviour {
        public GameObject Root;
        private void Awake() { 
            EventUtil.RemoveAllListener();
            Root.SetActive(true);
        }
    }
}