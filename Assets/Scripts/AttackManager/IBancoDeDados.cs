namespace AttackManager{
    public interface IBancoDeDados{
        public void SendJson(string json);
        public string GetJson(string path);
    }
}

