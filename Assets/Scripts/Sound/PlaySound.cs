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
}
