using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventExample : MonoBehaviour
{
    //Game object with play sound component
    PlaySound _playSound;

    void Start()
    {
        _playSound = GetComponent<PlaySound>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            _playSound.Play();
        }
    }
}
