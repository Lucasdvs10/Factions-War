using System;
using UnityEngine;
using StandardScripts;

public class EventGenerator: MonoBehaviour, IEventEmitter
{
    public event Action CharacterCreationEvent;

    public void CauseEvent(){
        CharacterCreationEvent?.Invoke();
    }

}
