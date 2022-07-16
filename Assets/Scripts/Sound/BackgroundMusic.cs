using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _backgroundSongs;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayBackGroundMusic());
    }
    
    IEnumerator PlayBackGroundMusic()
    {
        while (true)
        {
            foreach (AudioClip song in _backgroundSongs)
            {
                _audioSource.clip = song;
                _audioSource.Play();
                yield return new WaitForSeconds(_audioSource.clip.length);
            }
        }
    }
}
