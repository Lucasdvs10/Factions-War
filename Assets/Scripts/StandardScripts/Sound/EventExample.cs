using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventExample : MonoBehaviour
{
    //Game object with play sound component
    [SerializeField] PlaySound playSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            playSound.playSound();
        }
    }
}
