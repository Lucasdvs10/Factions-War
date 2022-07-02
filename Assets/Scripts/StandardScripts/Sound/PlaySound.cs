using System;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioSource _soundPlayer;
    [SerializeField] AudioClip _audioClip;

    //Play sound if there is no other sound being played on soundPlayer.Play()
    public void Play()
    {
        _soundPlayer.clip = _audioClip;
        _soundPlayer.Play();
    }

    public void Pause()
    {
        _soundPlayer.Pause();
    }

    public void UnPause()
    {
        _soundPlayer.UnPause();
    }

    //Play the sound without interfering with previous sounds
    public void PlayOneShot()
    {
        _soundPlayer.PlayOneShot(_audioClip, 0.7F);
    }

    public void Stop()
    {
        _soundPlayer.Stop();
    }
}
