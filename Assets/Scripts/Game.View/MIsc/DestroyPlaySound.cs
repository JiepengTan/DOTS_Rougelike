using System;
using System.Collections;
using System.Collections.Generic;
using GamesTan.Game.View;
using UnityEngine;
using Random = UnityEngine.Random;

public class DestroyPlaySound : MonoBehaviour {
    public List<AudioClip> Clips = new List<AudioClip>();

    private void OnDestroy() {
        if (Clips.Count > 0) {
            SoundManager.Instance.PlayAudio(Clips[Random.Range(0, Clips.Count)]);
        }
    }
}