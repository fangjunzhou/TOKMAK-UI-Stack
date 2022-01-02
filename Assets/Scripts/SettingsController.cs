using System;
using System.Collections;
using System.Collections.Generic;
using FinTOKMAK.UIStackSystem.Runtime;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class SettingsController : UIPanelChild
    {
        #region Public Field

        [BoxGroup("Panel References")]
        [ValidateInput("IsPanelValid", "The panel is not in the UIPanels in panelRootManager.")]
        public UIPanelElement settingsPanel;

        /// <summary>
        /// The action to trigger settings panel open.
        /// </summary>
        [BoxGroup("Panel References")]
        public InputAction escAction;
        
        #endregion

        #region Private Field

        #endregion

        private void Awake()
        {
            escAction.started += context =>
            {
                OpenSettingsPanel();
            };
        }

        #region Public Methods

        /// <summary>
        /// Call this method to open the settings panel in the UI Stack Manager
        /// </summary>
        public void OpenSettingsPanel()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
