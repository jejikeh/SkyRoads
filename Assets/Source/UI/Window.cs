using JetBrains.Annotations;
using UnityEngine;

namespace Source.UI
{
    public class Window : MonoBehaviour
    {
        [CanBeNull] protected object Data;

        public void OnOpenStart([CanBeNull] object data)
        {
            Data = data;
            OpenStart();
        }

        public void OnCloseStart()
        {
            CloseStart();
        }
        
        protected virtual void OpenStart() { }
        protected virtual void CloseStart() { }
    }
}