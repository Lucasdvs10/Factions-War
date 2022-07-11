using AttackManager;

namespace StandardScripts.AttackManager{
    public abstract class BaseController{
        protected IBancoDeDados _db;
        protected TroopListGroup _troopListGroup;

        protected abstract void CreateTroopGroup();
    }
}