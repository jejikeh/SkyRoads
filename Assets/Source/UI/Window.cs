﻿using System.Threading.Tasks;
using JetBrains.Annotations;
using Source.Core;
using UnityEngine;

namespace Source.UI
{
    public class Window : Entity
    {
        [CanBeNull] protected object Data;
        
        public async Task OnOpenStart([CanBeNull] object data)
        {
            Data = data;
            await OpenStart();
        }

        public async Task OnCloseStart()
        {
            await CloseStart();
        }
        
        protected virtual Task OpenStart() { return  Task.CompletedTask; }
        protected virtual Task CloseStart() { return Task.CompletedTask; }

        [CanBeNull]
        public virtual GameObject GetFirstSelectedButton()
        {
            return null;
        }
    }
}