using System;
using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.UIStackSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class SettingsButtonController : UIPanelChild
    {
        #region Public Field

        [BoxGroup("Panel References")]
        [ValidateInput("IsPanelValid", "The panel is not in the UIPanels in panelRootManager.")]
        public UIPanelElement settingsPanel;
        
        #endregion

        #region Private Field

        #endregion

        #region Public Methods

        /// <summary>
        /// Call this method to open the settings panel in the UI Stack Manager
        /// </summary>
        public void OpenSettingsPanel()
        {
            rootPanel.panelRootManager.AsyncPush(settingsPanel, rootPanel , 0.1f);
        }

        #endregion
    }
}
