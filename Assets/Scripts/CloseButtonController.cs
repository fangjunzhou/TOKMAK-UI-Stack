using FinTOKMAK.UIStackSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;

namespace DefaultNamespace
{
    public class CloseButtonController : UIPanelChild
    {

        #region Public Methods

        /// <summary>
        /// Call this method to close the settings panel.
        /// The method will check if settings panel is on the top of the stack.
        /// Otherwise, it will do nothing
        /// </summary>
        public void CloseSettingsPanelIfOnTop()
        {
            if (rootPanel.panelRootManager.Peek() == rootPanel)
            {
                rootPanel.panelRootManager.Pop();
            }
        }

        #endregion
    }
}