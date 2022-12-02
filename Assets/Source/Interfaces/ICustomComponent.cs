namespace Source.Interfaces
{
    public interface ICustomComponent
    {
        public void Start();
        public void Update();
        public void Enable();
        public void Disable();
        public bool Enabled { get; }
    }
}