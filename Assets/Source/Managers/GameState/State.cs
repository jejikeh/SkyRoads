namespace Source.Managers.GameState
{
    public abstract class State
    {
        public abstract void Set(object data = null);
        public abstract void Unset();
    }
}