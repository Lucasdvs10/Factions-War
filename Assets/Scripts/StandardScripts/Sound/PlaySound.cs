using StandardScripts;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] AudioSource soundPlayer;
    [SerializeField] AudioClip audioClip;


    private void OnEnable() {
        var eventToListen = GetComponent<IEventEmitter>();
        if(eventToListen != null)
            eventToListen.CharacterCreationEvent += playSound;
    }

    private void OnDisable() {
        var eventToListen = GetComponent<IEventEmitter>();
        if(eventToListen != null)
            eventToListen.CharacterCreationEvent -= playSound;
    }

    public void playSound()
    {
        soundPlayer.clip = audioClip;
        soundPlayer.Play();
    }
}
