using UnityEngine;

namespace GamesTan.Game.View {
    public class SoundManager : BaseMonoManager<SoundManager> {
        public AudioSource efxSource;
        public AudioSource musicSource;
        public float lowPitchRange = .95f;
        public float highPitchRange = 1.05f;

        public void PlayAudio(string audioName, bool randomizePitch) {
            var audioClip = Resources.Load<AudioClip>("Audio/" + audioName);

            if (audioClip != null) {
                Play(audioClip, randomizePitch);
            }
        }

        void Play(AudioClip clip, bool randomize = false) {
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

        void StopMusic() {
            musicSource.Stop();
        }
    }
}
