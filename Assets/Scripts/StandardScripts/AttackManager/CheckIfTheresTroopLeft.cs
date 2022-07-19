using UnityEngine;
using UnityEngine.Events;

namespace StandardScripts.AttackManager{
    public class CheckIfTheresTroopLeft : MonoBehaviour{
        public UnityEvent TheresNoTroopLeft;


        public void OnDestroy() {
            if(!GameObject.FindWithTag("Attackers"))
                TheresNoTroopLeft?.Invoke();
                
        }
    }
}