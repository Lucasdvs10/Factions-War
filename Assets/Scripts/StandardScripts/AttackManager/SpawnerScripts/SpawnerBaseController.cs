using AttackManager;

namespace StandardScripts.AttackManager{
    public class SpawnerBaseController : BaseController{
        private AttackTroopsSpawner _northSpawner;
        private AttackTroopsSpawner _southSpawner;
        private AttackTroopsSpawner _eastSpawner;
        private AttackTroopsSpawner _westSpawner;


        public void InitializeSpawners() {
            CreateTroopGroup();
            _northSpawner.TroopsToBeSpawnedList = _troopListGroup.NorthList;
            _southSpawner.TroopsToBeSpawnedList = _troopListGroup.SouthList;
            _eastSpawner.TroopsToBeSpawnedList = _troopListGroup.EastList;
            _westSpawner.TroopsToBeSpawnedList = _troopListGroup.WestList;
        }
        
        protected override void CreateTroopGroup() {
            var jsonHandler = new JsonHandler();
            _troopListGroup = jsonHandler.GetObjectFromJson<TroopListGroup>(_db.GetJsonStringFromDataBase());
        }
        
        public SpawnerBaseController(IBancoDeDados db, AttackTroopsSpawner northSpawner, AttackTroopsSpawner southSpawner, AttackTroopsSpawner eastSpawner, AttackTroopsSpawner westSpawner) {
            _db = db;
            _northSpawner = northSpawner;
            _southSpawner = southSpawner;
            _eastSpawner = eastSpawner;
            _westSpawner = westSpawner;
        }
    }
}