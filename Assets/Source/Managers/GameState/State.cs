using System.Threading.Tasks;

namespace Source.Managers.GameState
{
    public abstract class State
    {
        public abstract void Set();

        public abstract void Unset();
    }
}