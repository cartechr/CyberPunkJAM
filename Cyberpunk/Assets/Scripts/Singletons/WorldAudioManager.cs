using UnityEngine;
using UnityEngine.Audio;

namespace HL
{
    public class WorldAudioManager : MonoBehaviour
    {
        [HideInInspector] public static WorldAudioManager Instance { get; private set; }

        [Header("Volumes")]
        [SerializeField] private AK.Wwise.RTPC masterVolumeRTPC;
        [SerializeField] private AK.Wwise.RTPC musicVolumeRTPC;
        [SerializeField] private AK.Wwise.RTPC soundFXVolumeRTPC;
        [Range(0.001f, 1)] public float startAllSlidersAtThisVolume;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            SetMasterVolume(startAllSlidersAtThisVolume);
            SetMusicVolume(startAllSlidersAtThisVolume);
            SetSoundFXVolume(startAllSlidersAtThisVolume);
        }

        public void SetMasterVolume(float sliderValue)
        {
            masterVolumeRTPC.SetGlobalValue(sliderValue * 100);
        }

        public void SetMusicVolume(float sliderValue)
        {
            musicVolumeRTPC.SetGlobalValue(sliderValue * 100);
        }

        public void SetSoundFXVolume(float sliderValue)
        {
            soundFXVolumeRTPC.SetGlobalValue(sliderValue * 100);
        }
    }
}