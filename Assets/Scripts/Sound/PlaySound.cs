using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioSource soundPlayer;

    public void playSound()
    {
        soundPlayer.Play();
    }
}