using FinTOKMAK.UIStackSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;

namespace DefaultNamespace
{
    public class CloseButtonController : MonoBehaviour
    {
        #region Public Field
        
        [BoxGroup("Panel References")]
        [Required]
        public UIPanelElement currentPanel;
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Call this method to close the settings panel.
        /// The method will check if settings panel is on the top of the stack.
        /// Otherwise, it will do nothing
        /// </summary>
        public void CloseSettingsPanelIfOnTop()
        {
            if (currentPanel.panelRootManager.Peek() == currentPanel)
            {
                currentPanel.panelRootManager.Pop();
            }
        }

        #endregion
    }
}