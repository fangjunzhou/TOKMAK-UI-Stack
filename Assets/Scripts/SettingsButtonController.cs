using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.UIStackSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;

namespace DefaultNamespace
{
    public class SettingsButtonController : MonoBehaviour
    {
        #region Public Field

        #region Panel References

        [BoxGroup("Panel References")]
        [Required]
        public UIPanelElement currentPanel;

        [BoxGroup("Panel References")]
        [ValidateInput("IsPanelValid", "The panel is not in the UIPanels in panelRootManager.")]
        public UIPanelElement settingsPanel;

        #endregion

        #endregion

        #region Naughty Attribute Methods

        /// <summary>
        /// This method is used to check if the panel is a valid panel in current panelRootManager
        /// </summary>
        /// <param name="panelElement">the panel passed in to check</param>
        /// <returns>if the panel is valid</returns>
        private bool IsPanelValid(UIPanelElement panelElement)
        {
            if (currentPanel == null || panelElement == null || !currentPanel.panelRootManager.UIPanels.ContainsKey(panelElement))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Call this method to open the settings panel in the UI Stack Manager
        /// </summary>
        public void OpenSettingsPanel()
        {
            currentPanel.panelRootManager.Push(settingsPanel);
        }

        #endregion
    }
}
