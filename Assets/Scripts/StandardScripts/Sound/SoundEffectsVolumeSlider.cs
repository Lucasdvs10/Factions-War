using UnityEngine;
using UnityEngine.Audio;

public class SoundEffectsVolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    public void SetVolume(float sliderValue)
    {
        _audioMixer.SetFloat("SoundEffectsVolume", Mathf.Log10(sliderValue) * 20);
    }
}