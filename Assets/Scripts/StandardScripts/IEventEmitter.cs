using System;

namespace StandardScripts{
    public interface IEventEmitter{
        event Action CharacterCreationEvent;
    }
}