using System;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    public class UIStackEventInvoker : MonoBehaviour, IUIStackEventInvoker
    {
        public Action finishAction { get; set; }

        #region Public Methods

        /// <summary>
        /// Call this method when teh UI finished animation or logic
        /// </summary>
        public void Finish()
        {
            finishAction?.Invoke();
        }

        #endregion
    }
}