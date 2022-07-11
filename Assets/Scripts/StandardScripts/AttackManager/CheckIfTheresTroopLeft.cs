using UnityEngine;
using UnityEngine.Events;

namespace StandardScripts.AttackManager{
    public class CheckIfTheresTroopLeft : MonoBehaviour{
        public UnityEvent TheresNoTroopLeft;


        private void OnDestroy() {
            if(!GameObject.FindWithTag("Attackers"))
                TheresNoTroopLeft?.Invoke();
        }
    }
}