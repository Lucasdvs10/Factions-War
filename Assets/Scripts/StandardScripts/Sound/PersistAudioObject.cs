using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will prevent for more than one AudioSource prefab exists at the same time, and will keep audio when changing scenes
public class PersistAudioObject : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioSource");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
