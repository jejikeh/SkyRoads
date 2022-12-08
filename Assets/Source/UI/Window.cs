using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Source.UI
{
    public class Window : MonoBehaviour
    {
        [CanBeNull] protected object UnparsedData;
        
        public async Task OpenStartAsync(object data)
        {
            UnparsedData = data;
            await OnOpenStart();
        }

        public async Task OpenStartAsync()
        {
            await OnOpenStart();
        }

        public async Task OpenCompleteAsync()
        {
            await OnOpenComplete();
        }

        public async Task CloseStartAsync()
        {
            await OnCloseStart();
        }

        public async Task CloseCompleteAsync()
        {
            await OpenCompleteAsync();
        }

        protected virtual async Task OnOpenStart() { }
        protected virtual async Task OnOpenComplete() { }
        protected virtual async Task OnCloseStart() { }
        protected virtual async Task OnCloseComplete() { }
    }
}