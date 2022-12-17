namespace Source.Interfaces
{
    public interface  ICustomComponent
    {
        public void Update(float timeScale);
        public void Enable();
        public void Disable();
        public void Destroy();
        public bool Enabled { get; }
    }
}