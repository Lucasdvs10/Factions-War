using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioSource soundPlayer;
    [SerializeField] AudioClip audioClip;

    public void playSound()
    {
        soundPlayer.clip = audioClip;
        soundPlayer.Play();
    }

    public void pauseSound()
    {
        soundPlayer.Pause();
    }

    public void unPauseSound()
    {
        soundPlayer.UnPause();
    }

    public void playOneShot()
    {
        soundPlayer.PlayOneShot(audioClip, 1.0F);
    }

    public void stop()
    {
        soundPlayer.Stop();
    }
}
