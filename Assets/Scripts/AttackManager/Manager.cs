using UnityEngine;

namespace AttackManager{
    public abstract class Manager : MonoBehaviour{
        protected IBancoDeDados _db;
        protected TroopListGroup _troopListGroup;

        protected virtual void GetTroopFromJson() {
            var jsonString = _db.GetJsonString();
            _troopListGroup = JsonUtility.FromJson<TroopListGroup>(jsonString);
        }

        protected virtual void SendJsonStringToDB() {
            var jsonString = JsonUtility.ToJson(_troopListGroup);
            _db.SendJson(jsonString);
        }
        
    }
}