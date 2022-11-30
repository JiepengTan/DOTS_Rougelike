using GamesTan.ECS.Game;
using UnityEngine;

namespace GamesTan.Game.View {
    public class SoundManager : BaseMonoManager<SoundManager> {
        public AudioSource efxSource;
        public AudioSource musicSource;
        public float lowPitchRange = .95f;
        public float highPitchRange = 1.05f;

        public override void DoAwake() {
            base.DoAwake();
            EventUtil.AddListener(EGameEvent.GameEventPlayerMoved, OnEvent_GameEventPlayerMoved);
        }

        void OnEvent_GameEventPlayerMoved(object param) {
            PlayAudio("scavengers_footstep" + (Random.Range(1,2).ToString()),true);
        }

        public void PlayAudio(string audioName, bool randomizePitch) {
            var audioClip = Resources.Load<AudioClip>("Audio/" + audioName);

            if (audioClip != null) {
                PlayAudio(audioClip, randomizePitch);
            }
        }

        public void PlayAudio(AudioClip clip, bool randomize = false) {
            if(clip == null) return;
            if(!Contexts.GameData.IsPlaying) return;
            efxSource.clip = clip;

            if (!randomize) {
                efxSource.Play();
                return;
            }

            var originalPitch = efxSource.pitch;
            efxSource.pitch = Random.Range(lowPitchRange, highPitchRange);
            efxSource.Play();
            efxSource.pitch = originalPitch;
            return;
        }

        public void StopMusic() {
            musicSource.Stop();
        }
        public void PlayerMusic() {
            musicSource.Play();
        }
    }
}
