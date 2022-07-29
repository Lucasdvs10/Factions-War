using UnityEngine;
using UnityEngine.Audio;

public class MusicVolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    public void SetVolume(float sliderValue)
    {
        _audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
}
