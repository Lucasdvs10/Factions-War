using UnityEngine;

public class SoundOnNotBeingAbleToSpawn : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;
    }

    private void OnMouseDown()
    {
        _audioSource.Play();
    }
}
