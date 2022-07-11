using System;
using StandardScripts;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioSource soundPlayer;
    [SerializeField] AudioClip audioClip;


    private void OnEnable() {
        var eventToListen = GetComponent<IEventEmitter>();
       eventToListen.CharacterCreationEvent += playSound;
    }

    private void OnDisable() {
        var eventToListen = GetComponent<IEventEmitter>();
        eventToListen.CharacterCreationEvent -= playSound;
    }

    public void playSound()
    {
        soundPlayer.clip = audioClip;
        soundPlayer.Play();
    }
}
