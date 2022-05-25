using UnityEngine;

namespace AttackManager{
    public class AttackManager : MonoBehaviour{
        private IBancoDeDados _bd;
        private TroopListGroup _troopListGroup;
        
        

        public void SendAttackToDB(TroopListGroup group) {

            var conteudoJson = JsonUtility.ToJson(group, true);
            _bd.SendJson(conteudoJson);
        }

        public void GetAttackFromDB() {
            var stringJson = _bd.GetJson();
            _troopListGroup = JsonUtility.FromJson<TroopListGroup>(stringJson);
        }


    }
}