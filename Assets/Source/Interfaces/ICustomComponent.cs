using System.Threading;
using UnityEngine;

namespace Source.Interfaces
{
    public interface ICustomComponent
    {
        public void Update(float timeScale);
        public void Enable();
        public void Disable();
        public bool Enabled { get; }
    }
}