using System.Collections;
using System.Collections.Generic;
using StandardScripts;
using UnityEngine;

public class TroopParticle : MonoBehaviour
{
    public ParticleSystem particleSystem;

    void Start()
    {
        IEventEmitter eventToListen = GetComponent<IEventEmitter>();
        eventToListen.CharacterCreationEvent += shotParticles;
    }

    void shotParticles(){
        this.particleSystem.Play();
    }
}
