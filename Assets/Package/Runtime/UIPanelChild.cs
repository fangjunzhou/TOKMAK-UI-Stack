using NaughtyAttributes;
using UnityEngine;

namespace FinTOKMAK.UIStackSystem.Runtime
{
    public class UIPanelChild : MonoBehaviour
    {
        #region Public Field

        [BoxGroup("Root Panel")]
        [Required]
        public UIPanelElement rootPanel;

        #endregion
        
        #region Naughty Attribute Methods

        /// <summary>
        /// This method is used to check if the panel is a valid panel in current panelRootManager
        /// </summary>
        /// <param name="panelElement">the panel passed in to check</param>
        /// <returns>if the panel is valid</returns>
        private bool IsPanelValid(UIPanelElement panelElement)
        {
            if (rootPanel == null || panelElement == null || !rootPanel.panelRootManager.UIPanels.ContainsKey(panelElement))
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}