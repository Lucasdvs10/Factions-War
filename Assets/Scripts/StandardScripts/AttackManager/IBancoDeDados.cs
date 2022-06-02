namespace AttackManager{
    public interface IBancoDeDados{
        public void SendJsonStringToDataBase(string jsonString);
        public string GetJsonStringFromDataBase();
    }
}

